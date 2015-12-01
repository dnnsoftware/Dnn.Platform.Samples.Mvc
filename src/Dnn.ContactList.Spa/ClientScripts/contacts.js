if (typeof contactList === 'undefined' || contactList === null) {
    contactList = {};
};

contactList.contactsViewModel = function(config) {
    var self = this;
    var resx = config.resx;
    var util = config.util;
    var preloadedData = config.preloadedData;
    var $rootElement = config.$rootElement;

    util.contactService = function(){
        util.sf.serviceController = "Contact";
        return util.sf;
    };

    self.isEditMode = ko.observable(false);
    self.contacts = ko.observableArray([]);

    self.selectedContact = new contactList.contactViewModel(self, config);

    var toggleView = function() {
        self.isEditMode(!self.isEditMode());
    };

    self.addContact = function(){
        toggleView();
        self.selectedContact.init();
    };

    self.closeEdit = function() {
        toggleView();
        self.refresh();
    }

    self.editContact = function(data, e) {
        self.getContact(data.contactId());
        toggleView();
    };

    self.getContact = function (contactId, cb) {
        var params = {
            contactId: contactId
        };

        util.contactService().get("GetContact", params,
            function(data) {
                if (typeof data !== "undefined" && data != null && data.success === true) {
                    //Success
                    self.selectedContact.load(data.data.contact);
                } else {
                    //Error
                }
            },

            function(){
                //Failure
            }
        );

        if(typeof cb === 'function') cb();
    };

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

    self.init = function () {
        if (preloadedData) {
            self.load(preloadedData);
        } else {
            self.getContacts();
        }
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

    self.refresh = function() {
        self.getContacts();
    }
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

    self.cancel = function(){
        parentViewModel.closeEdit();
    };

    self.deleteContact = function (data, e) {
        var params = {
            contactId: data.contactId(),
            firstName: data.firstName(),
            lastName: data.lastName(),
            email: data.email(),
            phone: data.phone(),
            twitter: data.twitter()
        };

        util.contactService().post("DeleteContact", params,
            function(data){
                //Success
                parentViewModel.refresh();
            },

            function(data){
                //Failure
            }
        );
    };

    self.init = function(){
        self.contactId(-1);
        self.firstName("");
        self.lastName("");
        self.email("");
        self.phone("");
        self.twitter("");
    };

    self.load = function(data) {
        self.contactId(data.contactId);
        self.firstName(data.firstName);
        self.lastName(data.lastName);
        self.email(data.email);
        self.phone(data.phone);
        self.twitter(data.twitter);
    };

    self.saveContact = function(data, e) {
        var params = {
            contactId: data.contactId(),
            firstName: data.firstName(),
            lastName: data.lastName(),
            email: data.email(),
            phone: data.phone(),
            twitter: data.twitter()
        };

        util.contactService().post("SaveContact", params,
            function(data){
                //Success
                self.cancel();
            },

            function(data){
                //Failure
            }
        )


    };
};

