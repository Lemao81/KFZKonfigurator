$.binding = $.binding || {};

$.binding.createKoViewModel = $.binding.createKoViewModel ||
    function(viewModelJs, updateUrl) {
        debugger;
        var viewModel = ko.mapping.fromJS(viewModelJs);
        console.log(viewModel);
        var subscriptions = [];

        for (observable in viewModel) {
            if (viewModel.hasOwnProperty(observable) && viewModel[observable].subscribe) {
                var propertyName = observable;
                subscriptions.push(viewModel[observable].subscribe(function(newValue) {
                    debugger;
                    var data = {
                        PropertyName: propertyName,
                        NewValue: newValue
                    }

                    $.post(updateUrl, { data: data })
                        .done(function(changedViewModel) {
                            for (property in changedViewModel) {
                                if (changedViewModel.hasOwnProperty(property)) {
                                    viewModel[property](changedViewModel[property]);
                                }
                            }
                        });
                }));
            }
        }

        return viewModel;
    };