
$(document).ready(function () {
    $('#file').on('change', function () {
        var file = this.files[0];
        var reader = new FileReader();

        reader.onload = function (e) {
            $('.cover-preview').attr('src', e.target.result).removeClass('d-none');
        };

        reader.readAsDataURL(file);
    });
});
