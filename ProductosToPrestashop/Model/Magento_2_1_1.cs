using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosToPrestashop.Model
{
    //Lista de campos de Magento 2.1.1
    class Magento_2_1_1
    {
        // En esta versión no reconoce los campos de fecha como objetos DateTime, tuve que ponerlos como string
        // A la hora de mandarlos al prestashop debes de convertirlos primero a DateTime de esta forma:
        // DateTime.Parse(item.created_at);
        // Con los campos numéricos debe haber igual situación
        // Solo es parsear primero, los campos que son de dinero como price no se parsean a double, se parsean a decimal!!!!!!!! OJO !!!!!!!!

        public string sku { get; set; }
        public string store_view_code { get; set; }
        public string attribute_set_code { get; set; }
        public string product_type { get; set; }
        public string categories { get; set; }
        public string product_websites { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public string short_description { get; set; }
        public string weight { get; set; }
        public string product_online { get; set; }
        public string tax_class_name { get; set; }

        public string visibility { get; set; }
        public string price { get; set; }
        public string special_price { get; set; }
        public string special_price_from_date { get; set; }
        public string special_price_to_date { get; set; }
        public string url_key { get; set; }
        public string meta_title { get; set; }

        public string meta_keywords { get; set; }
        public string meta_description { get; set; }

        public string base_image { get; set; }
        public string base_image_label { get; set; }
        public string small_image { get; set; }
        public string small_image_label { get; set; }
        public string thumbnail_image { get; set; }
        public string thumbnail_image_label { get; set; }

        public string swatch_image { get; set; }
        public string swatch_image_label { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public string new_from_date { get; set; }
        public string new_to_date { get; set; }
        public string display_product_options_in { get; set; }
        public string map_price { get; set; }
        public string msrp_price { get; set; }
        public string map_enabled { get; set; }

        public string gift_message_available { get; set; }
        public string custom_design { get; set; }
        public string custom_design_from { get; set; }
        public string custom_design_to { get; set; }
        public string custom_layout_update { get; set; }

        public string page_layout { get; set; }
        public string product_options_container { get; set; }
        public string msrp_display_actual_price_type { get; set; }

        public string country_of_manufacture { get; set; }
        public string additional_attributes { get; set; }
        public string qty { get; set; }
        public string out_of_stock_qty { get; set; }
        public string use_config_min_qty { get; set; }
        public string is_qty_decimal { get; set; }
        public string allow_backorders { get; set; }
        public string use_config_backorders { get; set; }
        public string min_cart_qty { get; set; }

        public string use_config_min_sale_qty { get; set; }
        public string max_cart_qty { get; set; }
        public string use_config_max_sale_qty { get; set; }
        public string is_in_stock { get; set; }
        public string notify_on_stock_below { get; set; }
        public string use_config_notify_stock_qty { get; set; }
        public string manage_stock { get; set; }
        public string use_config_manage_stock { get; set; }
        public string use_config_qty_increments { get; set; }

        public string qty_increments { get; set; }
        public string use_config_enable_qty_inc { get; set; }
        public string enable_qty_increments { get; set; }
        public string is_decimal_divided { get; set; }
        public string website_id { get; set; }
        public string related_skus { get; set; }
        public string related_position { get; set; }
        public string crosssell_skus { get; set; }
        public string crosssell_position { get; set; }
        public string upsell_skus { get; set; }
        public string upsell_position { get; set; }
        public string additional_images { get; set; }
        public string additional_image_labels { get; set; }
        public string hide_from_product_page { get; set; }
        public string bundle_price_type { get; set; }
        public string bundle_sku_type { get; set; }
        public string bundle_price_view { get; set; }
        public string bundle_weight_type { get; set; }
        public string bundle_values { get; set; }
        public string bundle_shipment_type { get; set; }
        public string associated_skus { get; set; }
    }
}
