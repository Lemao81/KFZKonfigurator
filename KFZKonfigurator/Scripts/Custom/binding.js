$.binding = $.binding || {};

$.binding.createKoViewModel = $.binding.createKoViewModel ||
    function(viewModelJs, updateUrl) {
        var viewModel = ko.mapping.fromJS(viewModelJs);
        console.log(viewModel);
        var subscriptions = [];

        for (observable in viewModel) {
            if (viewModel.hasOwnProperty(observable) && viewModel[observable].subscribe) {
                subscriptions.push(viewModel[observable].subscribe(function(newValue) {
                    var propertyName = observable;

                    $.post(updateUrl, { property: propertyName, newValue: newValue })
                        .done(function(result) {
                            if (result.Error) {
                                alert(result.Error);
                            } else if (result.Price) {
                                viewModel['Price'](result.Price);
                            }
                        });
                }));
            }
        }

        return viewModel;
    };