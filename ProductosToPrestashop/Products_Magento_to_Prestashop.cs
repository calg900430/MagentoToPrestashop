using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;
using ProductosToPrestashop.Model;


namespace products_magento_to_prestashop
{
    /* 
      Cooper reviza el proyecto a ver si te cuadra, solo falta relacionar algunas propiedades del magento con el prestashop, ya que la mayoria de los
      campos del producto de Magento tiene nombres diferentes a los campo de prestashop y hay algunos campos de Magento que yo creó que no están implementados en 
      Prestashop,ya es tarde, lo haré mañana, en el código de enviar los 
      productos te deje unas notas de algunos detalles.Por lo otro todo esta OK , esto pincha bien.
   */
    public partial class FormpPrincipal : Form
    {
        string MyStringClear = "";
        string url_default = "http://127.0.0.1/prestashop/api";      
        string key_default = "WL1CDEW3EZ4EWXM1PFWCJB965HYEY4DV";
        string password = "";
        bool MyFalse = false;
        bool MyTrue = true;
        string MyClearString = "";
        int estado_hilo;
        bool state_close = true;
        StreamReader reader;
        string path_directory_imagenes = null;
      
        public FormpPrincipal()
        {
            InitializeComponent();
        }

        #region  Interfaz Visual
        //Cargar archivo CSV de los productos de Magento
        private void button_Cargar_FileCSV_Products_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Seleccionar Archivo CSV";
            openFileDialog1.Filter = "Fichero CSV|*.csv";
            openFileDialog1.RestoreDirectory = MyTrue;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                reader = new StreamReader(openFileDialog1.FileName);   
                state_close = MyTrue;
                return;
            }
            catch
            {
                MessageBox.Show("No se pudo cargar el archivo.Verifique que el archivo no este siendo usado por otro proceso y que tiene permiso para acceder al mismo.", "Cargar Archivo CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                state_close = MyFalse;
                return;
            }

        }
        //Cancelar
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            if (estado_hilo == (int)ThreadState.Running)
                hilo.Abort();  //Detiene el subproceso
        }
        //Evento Load
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_URL_APIWEB.Text = url_default;
            textBox_Key_APIWEB.Text = key_default;
        }
        //Insertar productos al prestashop
        private void button_Add_Products_Prestashop_Click(object sender, EventArgs e)
        {
            if (check_csv_url_and_key() == false)
            return;
            Hilo_InsertarTodos_Productos_to_Prestashop();
        }
        //Seleccionar Directorio de las imagenes de Magento
        private void button_Select_Imagenes_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Selecciona el directorio www/pub/media Magento 2.1.1";
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    path_directory_imagenes = folderBrowserDialog1.SelectedPath;
                }
            }
            catch
            {
                MessageBox.Show("No se pudo seleccionar el directorio.Verifique que el archivo no este siendo usado por otro proceso y que tiene permiso para acceder al mismo.", "Cargar Archivo CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                state_close = MyFalse;
                return;
            }
        }
        //Seleccionar Version del Magento
        private void comboBoxVersionMagento_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region  Funciones
        /*********Funciones***************/
        //Comprobar que el usuario haya insertado la url y la llave
        private bool check_csv_url_and_key()
        {
            //Comprobando que el usuario haya introducidos los datos
            if (textBox_URL_APIWEB.Text == MyStringClear)
            {
                MessageBox.Show("Introduzca la URL de la WEB API de Prestashop.", "WEB API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_Key_APIWEB.Text == MyStringClear)
            {
                MessageBox.Show("Introduzca la llave de la WEB API de Prestashop.", "WEB API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (reader == null || state_close == MyFalse)
            {
                MessageBox.Show("Cargue el archivo csv con los productos de Magento.", "Archivo CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        //Insertar Productos de Magento 2.1.1 a Prestashop
        public void InsertProductos_Magento211_Prestahsop()
        {
            state_close = MyFalse;
            block_buttons_cargar_csv(button_Cargar_FileCSV_Products, MyFalse);
            block_buttons_cargar_csv(button_Add_Products_Prestashop, MyFalse);
            block_buttons_select_directory(button_Select_Directory, MyFalse);
            //Incremento de la barra de progreso
            int increment_progrees_bar = 0;
            //Verfifica la versión de Magento seleccionada por el usuario y obtiene la cantidad de productos de la tienda de Magento 
            int count = 0;

            //Antes de agregar los productos debe agregar las categorias
            Bukimedia.PrestaSharp.Factories.CategoryFactory CategoriaFact = new Bukimedia.PrestaSharp.Factories.CategoryFactory(textBox_URL_APIWEB.Text, textBox_Key_APIWEB.Text, password);
            //Empleo un dictionario, para que la clave me sirva para saber si ya una categoria fue agregada o no
            Dictionary<string, Bukimedia.PrestaSharp.Entities.category> todasLasCategorias = new Dictionary<string, Bukimedia.PrestaSharp.Entities.category>();
            Dictionary<string, long?> CategoriasPadres = new Dictionary<string, long?>();
            using (var reader = new StreamReader(openFileDialog1.FileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Magento_2_1_1>();
                foreach (var item in records)
                {
                    long? lastIdAdded = 1;
                    // las categorias en magento vienen separadas por coma, porque un producto puede pertenecer a varias categorias
                    var lista = item.categories.Split(new char[] { ',' });   // se separan las diferentes categorias por producto
                    foreach (var cat in lista)                               // por cada categoria a la que pertenece cada producto se toman los diferentes niveles
                    {
                        // las categorias tienen niveles, aqui se separan por barras /
                        var nivelesCategorias = cat.Split(new char[] { '/' });
                        for (int i = 0; i < nivelesCategorias.Length; i++)
                        {
                            if (nivelesCategorias[i] == string.Empty) continue;
                            if (!todasLasCategorias.ContainsKey(nivelesCategorias[i]))
                            {
                                // parametros comunes a todas las categorias // solo se coge el nombre que es lo q exporta el magento
                                // el id lo genero yo de forma secuencial
                                var categoriaTmp = new Bukimedia.PrestaSharp.Entities.category();
                                categoriaTmp.active = 1;
                                categoriaTmp.AddName(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { id = 1, Value = nivelesCategorias[i] });
                                //categoriaTmp.AddDescription(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { id = 1, Value = nivelesCategorias[i] });
                                categoriaTmp.AddLinkRewrite(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { id = 1, Value = nivelesCategorias[i] });
                                //categoriaTmp.AddMetaDescription(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { id = 1, Value = nivelesCategorias[i] });
                                categoriaTmp.AddMetaTitle(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { id = 1, Value = nivelesCategorias[i] });
                                if (i == 0) // categoria raiz
                                {
                                    categoriaTmp.is_root_category = 1;
                                    categoriaTmp.id_parent = 1;  // Root por defecto
                                }
                                else  // es una subcategoria
                                {
                                    categoriaTmp.is_root_category = 0;
                                    categoriaTmp.id_parent = CategoriasPadres[nivelesCategorias[i - 1]];
                                }
                                todasLasCategorias.Add(nivelesCategorias[i], categoriaTmp);
                                lastIdAdded = CategoriaFact.Add(categoriaTmp).id;
                                CategoriasPadres.Add(nivelesCategorias[i], lastIdAdded);
                                categoriaTmp = null;
                            }
                        }
                    }
                }
            }
            try
            {
              using (CsvReader csv_count = new CsvReader(reader, CultureInfo.InvariantCulture))
              {
                 var elements = csv_count.GetRecords<Magento_2_1_1>();
                 count = elements.Count<Magento_2_1_1>();
              }

            }
            catch(CsvHelper.HeaderValidationException)
            {
               MessageBox.Show("El Archivo SCV de Productos de Magento es incompatible con está versión.Este software es compatible con Magento 2.1.1.", "WEB API", MessageBoxButtons.OK, MessageBoxIcon.Error);
               Set_Groupbox_Name(groupBox2, "En espera");
               block_buttons_cargar_csv(button_Cargar_FileCSV_Products, MyTrue);
               block_buttons_cargar_csv(button_Add_Products_Prestashop, MyTrue);
               Set_ProgressBar_Value(progressBar1);
               Set_Label(label4, "0%");
               hilo.Abort();
            }
            catch
            {
               MessageBox.Show("Error Desconocido en el archivo SCV.Este software es compatible con Magento 2.1.1.", "WEB API", MessageBoxButtons.OK, MessageBoxIcon.Error);
               Set_Groupbox_Name(groupBox2, "En espera");
               block_buttons_cargar_csv(button_Cargar_FileCSV_Products, MyTrue);
               block_buttons_cargar_csv(button_Add_Products_Prestashop, MyTrue);
               Set_ProgressBar_Value(progressBar1);
               Set_Label(label4, "0%");
               hilo.Abort();
            }
            //Establece el máximo de la barra de progreso
            Set_ProgressBar_Max(progressBar1, count);
            //Insertar Productos
            Set_Groupbox_Name(groupBox2, "Insertando Productos de Magento a Prestashop");
            //Indicador de porciento
            int porc = 0;
            try
            {
              using (reader = new StreamReader(openFileDialog1.FileName))
              using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
              {
                 var records = csv.GetRecords<Magento_2_1_1>();
                 //Objeto que permite acceder a la tabla productos
                 ProductFactory Producto = new ProductFactory(textBox_URL_APIWEB.Text, textBox_Key_APIWEB.Text, password);
                 //Objeto que permite acceder a la tabla imágenes
                 ImageFactory Imagen = new ImageFactory(textBox_URL_APIWEB.Text, textBox_Key_APIWEB.Text, password);
                 //Objeto que permite acceder a la tabla tienda
                 Bukimedia.PrestaSharp.Factories.StockAvailableFactory stockAvailableFactory = new StockAvailableFactory(textBox_URL_APIWEB.Text, textBox_Key_APIWEB.Text, password);
                 //Objeto que permite acceder a la tabla categorias
                 Bukimedia.PrestaSharp.Factories.CategoryFactory categoryFactory = new CategoryFactory(textBox_URL_APIWEB.Text, textBox_Key_APIWEB.Text, password);
                 var todasLasCategorias_existentes = categoryFactory.GetAll();
                 foreach (var item in records)
                 {
                    //Objeto que representa al producto actual
                    product psProduct = new product();
                   
                    /* Agregar los campos del producto de magento 2.1.1 a prestashop */
                    //  Campo1  ID_PRODUCT 
                    //  Campo2  ID_SUPPLIER  
                    //  Campo3  ID_MANUFACTURER  
                    //  Campo4  ID_CATEGORY_DEFAULT  
                    //  Campo5  ID_SHOP_DEFAULT
                    //  Campo6  ID_TAX_RULES_GROUP  
                    //  Campo7  ON_SALE 
                    //  Campo8  ONLINE_ONLY
                    if(item.product_online != "" )
                    {
                       if(int.Parse(item.product_online) >= 1)
                       psProduct.online_only = 1;
                       else
                       psProduct.online_only = 0;  
                    }
                    //  Camp9   EAN13
                    //  Campo10 ISBN 
                    //  Campo11 UPC 
                    //  Campo12 ECOTAX
                    //  Campo13 QUANTITY (De acceso)
                    //  Campo14 MINIMAL_QUANTITY    
                    //  Campo15 LOW_STOCK_THRESHOLD   
                    //  Campo16 LOW_STOCK_ALERT   
                    //  Campo17 PRICE
                    if(item.price != MyClearString)
                    psProduct.price = decimal.Parse(item.price); 
                    //  Campo18 WHOLE_SALE_PRICE    
                    //  Campo19 UNITY   
                    //  Campo20 UNITY_PRICE_RATIO    
                    //  Campo21 ADDITIONAL_SHIPPING_COST 
                    //  Campo22 REFERENCE
                    if(item.sku != MyClearString)
                    psProduct.reference = item.sku;
                    //  Campo23 SUPPLIER_REFERENCE
                    //  Campo24 LOCATION  
                    //  Campo25 WIDTH
                    //  Campo26 HEIGTH 
                    //  Campo27 DEPTH 
                    //  Campo28 WEIGHT 
                    if(item.weight != MyClearString)
                    psProduct.weight = decimal.Parse(item.weight);
                    //  Campo29 MINIMAL_QUANTITY    
                    //  Campo30 ADDITIONAL_DELIVERY_TIMES
                    //  Campo31 QUANTITY_DISCOUNT
                    //  Campo32 CUSTOMIZABLE
                    //  Campo33 UPLOADABLE_FILES  
                    //  Campo34 TEXT_FIELDS	
                    //  Campo35 ACTIVE 
                    psProduct.active = 1; //No encuentro el campo enabled de magento,asi que habilito todo los productos
                    //  Campo36 REDIRECT_TYPE   
                    //  Campo37 ID_TYPE_REDIRECT   
                    //  Campo38 AVAILABLE_FOR_ORDER 
                    psProduct.available_for_order = 1;
                    //  Campo39 AVAILABLE_DATE  
                 
                    //  Campo40 SHOW_CONDITION
                    psProduct.show_condition = 1;
                    //  Campo41 CONDITION
                    //  Campo42 SHOW_PRICE
                    psProduct.show_price = 1;
                    //  Campo43 INDEXED
                    //  Campo44 VISIBILITY
                    if(item.visibility == "Catalog, Search")
                    psProduct.visibility = "both";
                    else if(item.visibility == "Not Visible Individually")
                    psProduct.visibility = "none";
                    else if(item.visibility == "Catalog")
                    psProduct.visibility = "catalog";
                    else if(item.visibility == "Search")
                    psProduct.visibility = "search";
                    else
                    psProduct.visibility = "both";
                    //  Campo45 CACHE_IS_PACK     
                    //  Campo46 CACHE_HAS_ATTACHMENTS  
                    //  Campo47 IS_VIRTUAL  
                    //  Campo48 CACHE_DEFAULT_ATTRIBUTE   
                    //  Campo49 DATE_ADD (Fecha que se agregó el producto)
                    if(item.created_at != MyClearString)
                    {
                       try
                       {    
                         psProduct.date_add = DateTime.Parse(item.created_at).ToString("yyyy-MM-dd HH:mm:ss");
                         string[] param_fecha_time_magento = item.created_at.Split(',');                                      //Obtener la fecha-tiempo en el formato MM-dd-yyyy HH:mm:ss
                         string[] param_fecha__magento = param_fecha_time_magento[0].Split('/');                              //Obtener los parametros de la fecha dia,mes y año.
                         string formato_fecha_time_prestashop = param_fecha__magento[2] + "/" + param_fecha__magento[1] + "/" + param_fecha__magento[0] + "," + param_fecha_time_magento[1]; //Estableciendo el formato yyyy-mm-dd HH:mm:ss
                         psProduct.date_add = DateTime.Parse(formato_fecha_time_prestashop).ToString("dd-MM-yyyy HH:mm:ss"); //Fecha que se agregó el producto
                        }
                       catch(System.FormatException)
                       {
                         System.Windows.Forms.MessageBox.Show("Error al insertar las fechas,error en el formato.", "WEB API", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                         Set_Groupbox_Name(groupBox2, "En espera");
                         block_buttons_cargar_csv(button_Cargar_FileCSV_Products, MyTrue);
                         block_buttons_cargar_csv(button_Add_Products_Prestashop, MyTrue);
                         block_buttons_select_directory(button_Select_Directory, MyTrue);
                         Set_ProgressBar_Value(progressBar1);
                         Set_Label(label4, "0%");
                         hilo.Abort();
                       }
                    }
                    //Campo50 DATE_UPD (Fecha que se actualizó el producto) 
                    if(item.updated_at != MyClearString)
                    try
                    {
                        psProduct.date_upd = DateTime.Parse(item.updated_at).ToString("yyyy-MM-dd HH:mm:ss");
                        string[] param_fecha_time_magento = item.updated_at.Split(',');         //Obtener la fecha-tiempo en el formato  MM-dd-yyyy HH:mm:ss
                        string[] param_fecha__magento = param_fecha_time_magento[0].Split('/'); //Obtener los parametros de la fecha dia,mes y año.
                        string formato_fecha_time_prestashop = param_fecha__magento[2] + "/" + param_fecha__magento[0] + "/" + param_fecha__magento[1] + "," + param_fecha_time_magento[1]; //Estableciendo el formato yyyy-mm-dd HH:mm:ss
                        psProduct.date_upd = DateTime.Parse(formato_fecha_time_prestashop).ToString("yyyy-MM-dd HH:mm:ss"); //Fecha que se agregó el producto
                    }
                    catch(System.FormatException)
                    {
                        System.Windows.Forms.MessageBox.Show("Error al insertar las fechas,error en el formato.", "WEB API", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        Set_Groupbox_Name(groupBox2, "En espera");
                        block_buttons_cargar_csv(button_Cargar_FileCSV_Products, MyTrue);
                        block_buttons_cargar_csv(button_Add_Products_Prestashop, MyTrue);
                        block_buttons_select_directory(button_Select_Directory, MyTrue);
                        Set_ProgressBar_Value(progressBar1);
                        Set_Label(label4, "0%");
                        hilo.Abort();
                    }
                    //  Campo51 ADVANCED_STOCK_MANAGEMENT  
                    //  Campo52 PACK_STOCK_TYPE    
                    //  Campo53 STATE 
                    psProduct.state = 1;
                    /* Campos de otras tablas relacionadas con la tabla productos.*/
                    // CAMPO DESCRIPTION
                    psProduct.description.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { Value = item.description, id = 1 });
                    // CAMPO DESCRIPTION_SHORT
                    if(item.short_description.Length > 800)           
                    {
                      string new_short_description=item.short_description.Remove(799, item.short_description.Length - 800); //Trunca el string al máximo valor
                      psProduct.description_short.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { Value = new_short_description, id = 1 });
                    }
                    else
                    psProduct.description_short.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { Value = item.short_description, id = 1 });
                    // CAMPO META_DESCRIPTION 
                    psProduct.meta_description.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { Value = item.meta_description, id = 1 });
                    // META_Keywords 
                    psProduct.meta_keywords.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { Value = item.meta_keywords, id = 1 });
                    // META_TITLE 
                    psProduct.meta_title.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { Value = item.meta_title, id = 1 });
                    // CAMPO NAME
                    psProduct.AddName(new Bukimedia.PrestaSharp.Entities.AuxEntities.language() { Value = item.name, id = 1 });
                    //Agregar al PrestaShop el objeto psProduct
                    psProduct = Producto.Add(psProduct);
                    //Cantidad
                    var todosStocks = stockAvailableFactory.GetAll();
                    // en psProduct.id tienes el id asignado por el prestashop a ese producto
                    // luego solo tienes que buscar en todos los stock que hay por ese id de  producto y cambiar la propiedad quantity
                    if(item.qty != MyClearString)
                    {
                      todosStocks.Find(x => x.id_product == psProduct.id).quantity = int.Parse(item.qty);  //la cantidad
                      stockAvailableFactory.UpdateList(todosStocks);
                    }
                    //CAMPO CATEGORIA(Asocia un Producto con su Categoria)
                    long? id_producto = psProduct.id; 
                    var lascategorias = item.categories.Split(new char[] {','});
                    
                    foreach (var cat1 in lascategorias)
	                {
                       var nombreCategoria = cat1.Split(new char[]{'/'}).Last();
                       if(nombreCategoria!= MyClearString)
                       {
                          var categoriaPrestaShop = todasLasCategorias_existentes.Find(x => x.name[0].Value == nombreCategoria);
                          psProduct.associations.categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category(){id = (long)categoriaPrestaShop.id });
                          Producto.Update(psProduct);
                       }
	                }
                    //CAMPO IMAGEN
                    string path_virtual = item.base_image.Replace("/", "\\");                          //Convirtiendo la dirección virtual en la real.
                    string path_real = path_directory_imagenes + "\\catalog\\product" + path_virtual;  //Creando la ruta real de la imagen.
                    string name_imagen = Path.GetFileName(path_real);                                  //Obtiene el nombre de la imagen base.
                    //Verifica si la imagen se encuentra realmente en esta ruta
                    if (File.Exists(path_real))
                    {
                       try
                       {
                         Imagen.AddProductImage((long)psProduct.id, path_real);
                         string[] additional_imagen = item.additional_images.Split(','); //Imágenes Adicionales
                         //Verifica si el producto tiene imágenes adicionales
                         if(additional_imagen.Length > 1)
                         {
                           for (int i = 0; i < additional_imagen.Length - 1; i++)
                           {
                             string path_virtual_additional_imagenes = additional_imagen[i].Replace("/", "\\");
                             string path_real_additional_imagenes = path_directory_imagenes + "\\catalog\\product" + path_virtual_additional_imagenes;
                             Imagen.AddProductImage((long)psProduct.id, path_real_additional_imagenes);
                           }
                         }
                       }
                       catch
                       {
                         System.Windows.Forms.MessageBox.Show("Error al insertar la imagen del producto " + item.name + ".URL no encontrada en el servidor o la llave no tiene suficientes privilegios o es incorrecta.No se insertaron todos los productos en la base de datos de Prestashop.", "WEB API", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                         Set_Groupbox_Name(groupBox2, "En espera");
                         block_buttons_cargar_csv(button_Cargar_FileCSV_Products, MyTrue);
                         block_buttons_cargar_csv(button_Add_Products_Prestashop, MyTrue);
                         block_buttons_select_directory(button_Select_Directory, MyTrue);
                         Set_ProgressBar_Value(progressBar1);
                         Set_Label(label4, "0%");
                         hilo.Abort();
                       }
                    }
                    //Incrementa barra de progreso y actualiza el porciento.
                    Set_ProgressBar_Increment(progressBar1, 1);
                    porc = 100 * ++increment_progrees_bar / count;
                    Set_Label(label4, porc.ToString() + "%");
                 }
              }
            }
            catch (Bukimedia.PrestaSharp.PrestaSharpException)
            {
                System.Windows.Forms.MessageBox.Show("URL no encontrada en el servidor o la llave no tiene suficientes privilegios o es incorrecta.No se insertaron todos los productos en la base de datos de Prestashop.", "WEB API", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Set_Groupbox_Name(groupBox2, "En espera");
                block_buttons_cargar_csv(button_Cargar_FileCSV_Products, MyTrue);
                block_buttons_cargar_csv(button_Add_Products_Prestashop, MyTrue);
                block_buttons_select_directory(button_Select_Directory, MyTrue);
                Set_ProgressBar_Value(progressBar1);
                Set_Label(label4, "0%");
                hilo.Abort();
            }
            catch (System.UriFormatException)
            {
                System.Windows.Forms.MessageBox.Show("La URL no tiene el formato correcto.No se insertaron todos los productos en la base de datos de Prestashop.", "WEB API", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Set_Groupbox_Name(groupBox2, "En espera");
                block_buttons_cargar_csv(button_Cargar_FileCSV_Products, MyTrue);
                block_buttons_cargar_csv(button_Add_Products_Prestashop, MyTrue);
                block_buttons_select_directory(button_Select_Directory, MyTrue);
                Set_ProgressBar_Value(progressBar1);
                Set_Label(label4, "0%");
                hilo.Abort();
            }
            catch (CsvHelper.HeaderValidationException)
            {
                MessageBox.Show("El Archivo SCV de Productos de Magento es incompatible con está versión.Este software es compatible con Magento 2.X.X.", "WEB API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Set_Groupbox_Name(groupBox2, "En espera");
                block_buttons_cargar_csv(button_Cargar_FileCSV_Products, MyTrue);
                block_buttons_cargar_csv(button_Add_Products_Prestashop, MyTrue);
                block_buttons_select_directory(button_Select_Directory, MyTrue);
                Set_ProgressBar_Value(progressBar1);
                Set_Label(label4, "0%");
                hilo.Abort();
            }
            catch
            {
               System.Windows.Forms.MessageBox.Show("Error desconocido.No se insertaron todos los productos en la base de datos de Prestashop.", "WEB API", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
               Set_Groupbox_Name(groupBox2, "En espera");
               block_buttons_cargar_csv(button_Cargar_FileCSV_Products, MyTrue);
               block_buttons_cargar_csv(button_Add_Products_Prestashop, MyTrue);
               block_buttons_select_directory(button_Select_Directory, MyTrue);
               Set_ProgressBar_Value(progressBar1);
               Set_Label(label4, "0%");
               hilo.Abort();
            }
            MessageBox.Show("Todos los productos se agregaron a la tienda Prestashop.", "WEB API", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Set_Groupbox_Name(groupBox2, "En espera");
            block_buttons_cargar_csv(button_Cargar_FileCSV_Products, MyTrue);
            block_buttons_insertarproductos_prestashop(button_Add_Products_Prestashop, MyTrue);
            block_buttons_select_directory(button_Select_Directory, MyTrue);
            Set_ProgressBar_Value(progressBar1);
            Set_Label(label4, "0%");
        }
        //Insertar Productos de Magento 2.1.2 a Prestashop
        public void InsertProductos_Magento212_Prestahsop()
        {

        }

        /**********************************************************************************/
        #endregion

        #region  Acceder a un control visual desde un hilo
        private void Hilo_InsertarTodos_Productos_to_Prestashop()
        {
            hilo = new Thread(InsertProductos_Magento211_Prestahsop);
            hilo.SetApartmentState(ApartmentState.STA);
            hilo.Start();
            estado_hilo = hilo.ThreadState.GetHashCode();
        }
        Thread hilo;
        internal delegate void set_groupbox_name(GroupBox GB, string text);
        internal delegate void set_button_state(Button button, bool val);
        internal delegate void set_progressbar_max(ProgressBar PB, int val);
        internal delegate void set_progressbar_increment(ProgressBar PB, int val);
        internal delegate void set_progressbar_value(ProgressBar PB);
        internal delegate void set_label(Label L, string text);
        //Nombre del group box de estado
        void Set_Groupbox_Name(GroupBox groupbox, string name)
        {
            if (groupbox.InvokeRequired)
            {
                var setgroupbox = new set_groupbox_name(Set_Groupbox_Name);
                Invoke(setgroupbox, new object[] { groupbox, name });
            }
            else
            {
                groupbox.Text = name;
            }
        }
        //Bloquear y Desbloquear Botones
        void block_buttons_insertarproductos_prestashop(Button insertar, bool c)
        {
            if (insertar.InvokeRequired)
            {
                var a = new set_button_state(block_buttons_insertarproductos_prestashop);
                Invoke(a, new object[] { insertar, c });
            }
            else
            {
                insertar.Enabled = c;
            }
        }
        void block_buttons_cargar_csv(Button cargar_csv_insertardatos, bool c)
        {
            if (cargar_csv_insertardatos.InvokeRequired)
            {
                var setleer = new set_button_state(block_buttons_cargar_csv);
                Invoke(setleer, new object[] { cargar_csv_insertardatos, c });
            }
            else
            {
                cargar_csv_insertardatos.Enabled = c;
            }
        }
        void block_buttons_select_directory(Button cancelar, bool c)
        {
            if (cancelar.InvokeRequired)
            {
                var setleer = new set_button_state(block_buttons_select_directory);
                Invoke(setleer, new object[] { cancelar, c });
            }
            else
            {
                cancelar.Enabled = c;
            }
        }
        //ProgressBar Maximum
        void Set_ProgressBar_Max(ProgressBar progressbar, int value)
        {
            if (progressbar.InvokeRequired)
            {
                var setprogressbar = new set_progressbar_max(Set_ProgressBar_Max);
                Invoke(setprogressbar, new object[] { progressbar, value });
            }
            else
            {
                progressbar.Maximum = value;
            }
        }
        //ProgressBar Increment
        void Set_ProgressBar_Increment(ProgressBar progressbar, int value)
        {
            if (progressbar.InvokeRequired)
            {
                var setprogressbar = new set_progressbar_increment(Set_ProgressBar_Increment);
                Invoke(setprogressbar, new object[] { progressbar, value });
            }
            else
            {
                progressbar.Increment(value);
                progressbar.Update();
            }
        }
        //Iniciar nuevamente la barra de progreso.
        void Set_ProgressBar_Value(ProgressBar progressbar)
        {
            if (progressbar.InvokeRequired)
            {
                var setprogressbar = new set_progressbar_value(Set_ProgressBar_Value);
                Invoke(setprogressbar, new object[] { progressbar });
            }
            else
            {
                progressbar.Value = 0;
                progressbar.Update();
            }
        }
        //Label
        void Set_Label(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                var setlabel = new set_label(Set_Label);
                Invoke(setlabel, new object[] { label, text });
            }
            else
            {
                label.Text = text;
                label.Update();
            }
        }


        #endregion

       
    }
}
