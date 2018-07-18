$.binding = $.binding || {};
$.binding.CommitStrategy = $.binding.CommitStrategy || { ON_CHANGE: 0, ON_FOCUS_LOS: 1, NONE: 2 }

$.binding.createKoViewModel = $.binding.createKoViewModel ||
    function(viewModelJs, commitStrategies, updateUrl) {
        var viewModel = ko.mapping.fromJS(viewModelJs);

        var subscriptions = [];
        _.mapObject(viewModel,
            function(value, key) {
                if (commitStrategies[key] === $.binding.CommitStrategy.ON_CHANGE && value.subscribe) {
                    subscriptions.push(value.subscribe(function(newValue) {
                        newValue && update(key, newValue);
                    }));
                }
            });

        viewModel.onFocusLost = function(propertyName) {
            if (commitStrategies[propertyName] === $.binding.CommitStrategy.ON_FOCUS_LOS) {
                update(propertyName, viewModel[propertyName]());
            }
        };

        function update(propertyName, newValue) {
            $.post(updateUrl, { propertyName: propertyName, newValue: newValue })
                .done(function(result) {
                    if (result.Error) {
                        $.utils.showDialog('Fehler', result.Error);
                    } else if (result.PriceLabel) {
                        viewModel['PriceLabel'](result.PriceLabel);
                    }
                });
        };

        return viewModel;
    };