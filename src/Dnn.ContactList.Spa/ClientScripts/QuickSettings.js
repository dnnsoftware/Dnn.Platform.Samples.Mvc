var dnn = dnn || {};
dnn.modules = dnn.modules || {};
dnn.modules.spa = dnn.modules.spa || {};
dnn.modules.spa.dnnContactListSpa = dnn.modules.spa.dnnContactListSpa || {};

dnn.modules.spa.dnnContactListSpa.quickSettings = function (root, moduleId) {
    // The function dnnQuickSettings definded in 'ModuleActions.js' requires working with promises.
    var SaveSettings = function () {
        var deferred = $.Deferred();
        deferred.resolve();
        return deferred.promise();
    };

    var CancelSettings = function () {
        var deferred = $.Deferred();
        deferred.resolve();
        return deferred.promise();
    };

    var init = function () {
        // dnnQuickSettings needs three parameters: moduleId, onSave and onCancel.
        // These two functions are associated to the save and cancel buttons and the
        // callbacks mechanism is based on promises.
        $(root).dnnQuickSettings({
            moduleId: moduleId,
            onSave: SaveSettings,
            onCancel: CancelSettings
        });
    }

    return {
        init: init
    }
};
