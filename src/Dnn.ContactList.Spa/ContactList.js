function ContactList($, ko, settings, resx){
    var $rootElement;

    var viewModel = {};

    var init = function(element) {
        $rootElement = $(element);

        var config = {
            settings: settings,
            resx: resx,
            util: contactList.utility(settings, resx),
            $rootElement: $rootElement
        };

        viewModel = new contactList.contactsViewModel(config);
        viewModel.init();

        viewModel.getContacts();

        ko.applyBindings(viewModel, $rootElement[0]);
    }

    return {
        init: init
    }
}