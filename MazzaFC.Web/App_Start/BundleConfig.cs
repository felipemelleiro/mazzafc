using System.Web;
using System.Web.Optimization;

namespace MazzaFC.Web
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/app/global/module.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/usuario").Include(
                        "~/Scripts/app/usuario/usuarioRepository.js",
                        "~/Scripts/app/usuario/usuarioController.js"));

            bundles.Add(new ScriptBundle("~/bundles/medico").Include(
                        "~/Scripts/app/medico/medicoRepository.js",
                        "~/Scripts/app/medico/medicoController.js"));

            bundles.Add(new ScriptBundle("~/bundles/paciente").Include(
                        "~/Scripts/app/paciente/pacienteRepository.js",
                        "~/Scripts/app/paciente/pacienteController.js"));

            bundles.Add(new ScriptBundle("~/bundles/agendamento").Include(
                        "~/Scripts/app/agendamento/agendamentoRepository.js",
                        "~/Scripts/app/agendamento/agendamentoController.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
