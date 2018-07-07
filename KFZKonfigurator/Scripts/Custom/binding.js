$.binding = $.binding || {};

$.binding.createKoViewModel = $.binding.createKoViewModel ||
    function(viewModelJs, commitStrategies, updateUrl) {
        var viewModel = ko.mapping.fromJS(viewModelJs);

        var subscriptions = [];
        _.mapObject(viewModel,
            function(value, key) {
                if (commitStrategies[key] === 0 && value.subscribe) {
                    subscriptions.push(value.subscribe(function(newValue) {
                        newValue && update(key, newValue);
                    }));
                }
            });

        viewModel.onFocusLost = function(propertyName) {
            if (commitStrategies[propertyName] === 1) {
                update(propertyName, viewModel[propertyName]());
            }
        };

        function update(propertyName, newValue) {
            $.post(updateUrl, { propertyName: propertyName, newValue: newValue })
                .done(function(result) {
                    if (result.Error) {
                        $.utils.showDialog('Fehler', result.Error);
                    } else if (result.Price) {
                        viewModel['Price'](result.Price);
                    }
                });
        };

        return viewModel;
    };