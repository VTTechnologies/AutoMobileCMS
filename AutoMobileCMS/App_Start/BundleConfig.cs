using System.Web;
using System.Web.Optimization;

namespace AutoMobileCMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            string template2components = "~/Content/Template2Content/";
            string ltecomponents = "~/Scripts/adminlte/components/";
            string lteplugins = "~/Scripts/adminlte/plugins/";
            string lte = "~/Scripts/adminlte/";

            bundles.Add(new ScriptBundle("~/bundles/jquery")
              .Include(ltecomponents + "jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Common")
         .Include("~/Scripts/CommonJs/Common.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib")
              .Include(ltecomponents + "jquery-ui/jquery-ui.min.js")
              .Include(ltecomponents + "bootstrap/dist/js/bootstrap.min.js")
              .Include(ltecomponents + "bootstrap/dist/js/bootstrap-select.js")
              .Include(ltecomponents + "raphael/raphael.min.js")
              .Include(ltecomponents + "morris.js/morris.min.js")
              .Include(ltecomponents + "chart.js/Chart.min.js")
              .Include(ltecomponents + "chart.js/Chart.bundle.min.js")
              .Include(ltecomponents + "Flot/jquery.flot.js")
              .Include(ltecomponents + "Flot/jquery.flot.resize.js")
              .Include(ltecomponents + "Flot/jquery.flot.pie.js")
              .Include(ltecomponents + "Flot/jquery.flot.categories.js")
              .Include(ltecomponents + "jquery-sparkline/dist/jquery.sparkline.min.js")
              .Include(lteplugins + "jvectormap/jquery-jvectormap-1.2.2.min.js")
              .Include(lteplugins + "jvectormap/jquery-jvectormap-world-mill-en.js")
              .Include(ltecomponents + "jquery-knob/dist/jquery.knob.min.js")
              .Include(ltecomponents + "moment/moment.js")
              .Include(ltecomponents + "PACE/pace.min.js")
              .Include(ltecomponents + "ckeditor/ckeditor.js")
              .Include(ltecomponents + "datatables.net/js/jquery.dataTables.min.js")
              .Include(ltecomponents + "datatables.net-bs/js/dataTables.bootstrap.min.js")
              .Include(ltecomponents + "bootstrap-daterangepicker/daterangepicker.js")
              .Include(ltecomponents + "bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js")
              .Include(ltecomponents + "bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js")
              .Include(lteplugins + "bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js")
              .Include(ltecomponents + "jquery-slimscroll/jquery.slimscroll.min.js")
              .Include(ltecomponents + "fastclick/lib/fastclick.js")
              .Include(lte + "js/adminlte.min.js")
              .Include(lte + "js/demo.js")
              .Include(lteplugins + "bootstrap-slider/bootstrap-slider.js")
              .Include(ltecomponents + "select2/dist/js/select2.full.min.js")
              .Include(lteplugins + "input-mask/jquery.inputmask.js")
              .Include(lteplugins + "input-mask/jquery.inputmask.date.extensions.js")
              .Include(lteplugins + "input-mask/jquery.inputmask.extensions.js")
              .Include(lteplugins + "timepicker/bootstrap-timepicker.min.js")
              .Include(lteplugins + "iCheck/icheck.min.js")
              .Include(ltecomponents + "fullcalendar/dist/fullcalendar.min.js"));




            bundles.Add(new StyleBundle("~/Content/css")
               .Include(ltecomponents + "bootstrap/dist/css/bootstrap.min.css")
               .Include(ltecomponents + "bootstrap/dist/css/bootstrap-select.css")
               .Include(ltecomponents + "font-awesome/css/font-awesome.min.css")
               .Include(ltecomponents + "Ionicons/css/ionicons.min.css")
               .Include(ltecomponents + "datatables.net-bs/css/dataTables.bootstrap.min.css")
               .Include("~/Content/adminlte/css/AdminLTE.min.css")
               .Include("~/Content/adminlte/css/skins/_all-skins.min.css")
               .Include(ltecomponents + "morris.js/morris.css")
               .Include(ltecomponents + "jvectormap/jquery-jvectormap.css")
               .Include(ltecomponents + "bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css")
               .Include(ltecomponents + "bootstrap-daterangepicker/daterangepicker.css")
               .Include(lteplugins + "bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css")
               .Include(lteplugins + "bootstrap-slider/slider.css")
               .Include(ltecomponents + "select2/dist/css/select2.min.css")
               .Include(ltecomponents + "bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css")
               .Include(lteplugins + "timepicker/bootstrap-timepicker.min.css")
               .Include(lteplugins + "iCheck/all.css")
               .Include(lteplugins + "pace/pace.min.css")
               .Include(ltecomponents + "fullcalendar/dist/fullcalendar.min.css"));


            bundles.Add(new StyleBundle("~/Template2/Favicons")
                .Include(template2components + "img/favicon.png")
                .Include(template2components + "img/apple-touch-icon.png"));


            bundles.Add(new StyleBundle("~/Template2/Bootstrap")
               .Include(template2components + "lib/bootstrap/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Template2/LibrariesCss")
             .Include(template2components + "lib/font-awesome/css/font-awesome.min.css")
             .Include(template2components + "lib/animate/animate.min.css")
             .Include(template2components + "lib/ionicons/css/ionicons.min.css")
             .Include(template2components + "lib/owlcarousel/assets/owl.carousel.min.css")
             .Include(template2components + "lib/lightbox/css/lightbox.min.css")
             .Include(template2components + "css/style.css"));

            bundles.Add(new ScriptBundle("~/Template2/JavaScript")
               .Include(template2components + "lib/jquery/jquery.min.js")
               .Include(template2components + "lib/jquery/jquery-migrate.min.js")
               .Include(template2components + "lib/bootstrap/js/bootstrap.bundle.min.js")
               .Include(template2components + "lib/easing/easing.min.js")
               .Include(template2components + "lib/superfish/hoverIntent.js")
               .Include(template2components + "lib/superfish/superfish.min.js")
               .Include(template2components + "lib/wow/wow.min.js")
               .Include(template2components + "lib/waypoints/waypoints.min.js")
               .Include(template2components + "lib/counterup/counterup.min.js")
               .Include(template2components + "lib/owlcarousel/owl.carousel.min.js")
               .Include(template2components + "lib/isotope/isotope.pkgd.min.js")
               .Include(template2components + "lib/lightbox/js/lightbox.min.js")
               .Include(template2components + "lib/touchSwipe/jquery.touchSwipe.min.js")
               .Include(template2components + "contactform/contactform.js")
               .Include(template2components + "js/main.js"));

            bundles.Add(new ScriptBundle("~/ShopSold/Scripts")
                .Include("~/Scripts/js/vendor/jquery-1.12.0.min.js")
                .Include("~/Scripts/js/popper.js")
                .Include("~/Scripts/js/bootstrap.min.js")
                .Include("~/Scripts/js/isotope.pkgd.min.js")
                .Include("~/Scripts/js/imagesloaded.pkgd.min.js")
                .Include("~/Scripts/js/jquery.counterup.min.js")
                .Include("~/Scripts/js/waypoints.min.js")
                .Include("~/Scripts/js/owl.carousel.min.js")
                .Include("~/Scripts/js/plugins.js")
                .Include("~/Scripts/js/main.js")
                .Include("~/Content/js/vendor/modernizr-2.8.3.min.js"));

            bundles.Add(new StyleBundle("~/ShopSold/Styles")
                .Include("~/Content/css/bootstrap.min.css")
                .Include("~/Content/css/animate.css")
                .Include("~/Content/css/owl.carousel.min.css")
                .Include("~/Content/css/chosen.min.css")
                .Include("~/Content/css/icofont.css")
                .Include("~/Content/css/themify-icons.css")
                .Include("~/Content/css/font-awesome.min.css")
                .Include("~/Content/css/meanmenu.min.css")
                .Include("~/Content/css/bundle.css")
                .Include("~/Content/css/style.css")
                .Include("~/Content/css/responsive.css"));
        }
    }
}
