$.utils = $.utils || {};

$.utils.showDialog = $.utils.showDialog ||
    function (title, text) {
        $('#dialog-title').text(title);
        $('#dialog-text').text(text);
        $('#modal-dialog').modal();
    };