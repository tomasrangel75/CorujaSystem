using System.Web;
using System.Web.Optimization;

namespace CorujaPresentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {


            //js ///////////////////////////////////////////////////////////////

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/jquery*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
                       
            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            "~/Scripts/jquery.inputmask/inputmask.js",
            "~/Scripts/jquery.inputmask/jquery.inputmask.js",
            "~/Scripts/jquery.inputmask/inputmask.extensions.js",
            "~/Scripts/jquery.inputmask/inputmask.date.extensions.js",
            //and other extensions you want to include
            "~/Scripts/jquery.inputmask/inputmask.numeric.extensions.js"));


            bundles.Add(new ScriptBundle("~/bundles/coruja").Include(
                      "~/Scripts/coruja.js"));
            

           //css///////////////////////////////////////////////////////////////

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     
                      "~/Content/bootstrap.css",
                       "~/Content/site.css",
                       "~/Content/font-awesome.css",
                       "~/Content/font-coruja.css",
                       "~/Content/bootstrap-social.css",
                        "~/Content/bootstraptheme.css",
                         "~/Content/animate.css"
                      ));


        }
        
    }
}
