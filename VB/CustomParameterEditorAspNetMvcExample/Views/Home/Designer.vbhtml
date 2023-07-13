@ModelType DevExpress.XtraReports.UI.XtraReport

<script type="text/html" id="custom-parameter-editor">
    <div data-bind="dxTextBox: { value: value },
         dxValidator: { validationRules: [{ type: 'email', message: 'Email is not valid.' }]}">
    </div>
</script>
<script type="text/javascript">
    function reportDesignerInit(sender, e) {
        var editor = { header: "custom-parameter-editor" };
        sender.AddParameterType({
            displayValue: "Custom Type",
            specifics: "custom",
            value: "@GetType(CustomParameterEditorAspNetMvcExample.CustomParameterType).FullName",
            valueConverter: function(valueObj) { return valueObj; }
        }, editor);
    }
    function onCustomizeMenuActions(s, e) {
        var newReportAction = e.GetById(DevExpress.Reporting.Designer.Actions.ActionId.NewReport);
        if (newReportAction) {
            newReportAction.clickAction = function () {
                s.OpenReport("TemplateReport");
            }
        }
    }
</script>

@Html.DevExpress().ReportDesigner(
    Sub(settings)
        settings.Name = "ReportDesigner1"
        settings.ClientSideEvents.Init = "reportDesignerInit"
        settings.ClientSideEvents.CustomizeMenuActions = "onCustomizeMenuActions"
    End Sub).Bind("Model").GetHtml()
