$.binding = $.binding || {};

$.binding.createKoViewModel = $.binding.createKoViewModel ||
    function(viewModelJs, updateUrl) {
        var viewModel = ko.mapping.fromJS(viewModelJs);
        console.log(viewModel);
        var subscriptions = [];

        _.mapObject(viewModel,
            function (value, key) {
                if (value.subscribe) {
                    subscriptions.push(value.subscribe(function (newValue) {
                        newValue && $.post(updateUrl, { propertyName: key, newValue: newValue })
                            .done(function (result) {
                                if (result.Error) {
                                    $.utils.showDialog('Fehler', result.Error);
                                } else if (result.Price) {
                                    viewModel['Price'](result.Price);
                                }
                            });
                    }));
                }
            });

        return viewModel;
    };