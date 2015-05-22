if (typeof contactList === 'undefined' || contactList === null) {
    contactList = {};
};

contactList.contactsViewModel = function(config) {
    var self = this;
    var resx = config.resx;
    var util = config.util;
    var $rootElement = config.$rootElement;

    util.contactService = function(){
        util.sf.serviceController = "Contact";
        return util.sf;
    };

    self.contacts = ko.observableArray([]);

    self.getContacts = function () {
        var params = {
        };

        util.contactService().get("GetContacts", params,
            function(data) {
                if (typeof data !== "undefined" && data != null && data.success === true) {
                    //Success
                    self.load(data.data);
                } else {
                    //Error
                }
            },
            function(){
                //Failure
            }
        );
    };

    self.init = function(){
    };

    self.load = function(data) {
        self.contacts.removeAll();
        for(var i=0; i < data.results.length; i++){
            var result = data.results[i];
            var contact = new contactList.contactViewModel(self, config);
            contact.load(result);
            self.contacts.push(contact);
        }
    };
};

contactList.contactViewModel = function(parentViewModel, config) {
    var self = this;
    var resx = config.resx;
    var util = config.util;
    var $rootElement = config.$rootElement;

    self.parentViewModel = parentViewModel;
    self.contactId = ko.observable(-1);
    self.firstName = ko.observable('');
    self.lastName = ko.observable('');
    self.email = ko.observable('');
    self.phone = ko.observable('');
    self.twitter = ko.observable('');

    self.load = function(data) {
        self.contactId(data.contactId);
        self.firstName(data.firstName);
        self.lastName(data.lastName);
        self.email(data.email);
        self.phone(data.phone);
        self.twitter(data.twitter);
    };
};

