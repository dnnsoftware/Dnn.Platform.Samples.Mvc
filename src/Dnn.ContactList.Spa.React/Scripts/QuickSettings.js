var dnnspamodule = dnnspamodule || {};

dnnspamodule.quickSettings = function(root, moduleId) {

    // Setup your settings service endpoint
    /*
    var service = {
        path: "SPA_Module_React",
        framework: $.ServicesFramework(moduleId)
    }
    service.baseUrl = service.framework.getServiceRoot(service.path) + "Settings/";
    */

    var SaveSettings = function () {
        alert("Save Settings");
    };

    var CancelSettings = function () {

    };

    var LoadSettings = function () {

    };

    var init = function () {
        // Wire up the default save and cancel buttons
        $(root).dnnQuickSettings({
            moduleId: moduleId,
            onSave: SaveSettings,
            onCancel: CancelSettings
        });
        LoadSettings();
    }

    return {
        init: init
    }
};