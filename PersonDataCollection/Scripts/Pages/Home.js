$(function () {
    home.init();
});

var home = {
    init: function () {
        $(document)
            .on('click', '#staffButton', home.getStaffForm)
            .on('click', '#clientButton', home.getClientForm);
    },
    getClientForm: function (e) {
        $.ajax({
            type: 'GET',
            url: 'Home/GetClientForm',
            contentType: 'application/json',
            async: true,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("RequestVerificationToken",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function (html, status, xhr) { home.showForm(html); }
        });
    },
    getStaffForm: function (e) {
        $.ajax({
            type: 'GET',
            url: 'Home/GetStaffForm',
            contentType: 'application/json',
            async: true,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("RequestVerificationToken",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function (html, status, xhr) {
                home.showForm(html);
            }
        });
    },
    showForm: function (html) {
        $('#personForm').html(html);
        $('#personTypeContainer').hide();
        $('#feedback').hide();
        $(document)
            .on('click', '#submitStaff', home.submitStaff)
            .on('click', '#submitClient', home.submitClient);
    },
    personIsValid: function () {
        var $firstName = $('#firstName');
        var $lastName = $('#lastName');
        var $dateOfBirth = $('#dateOfBirth');
        var $feedback = $('#feedback');

        if ($firstName.val() === '') {
            $feedback.html("Enter your first name");
            $feedback.show();
            return false;
        }

        if ($lastName.val() === '') {
            $feedback.html("Enter your last name");
            $feedback.show();
            return false;
        }

        if (!Date.parse($dateOfBirth.val())) {
            $feedback.html("Enter your date of birth");
            $feedback.show();
            return false;
        }

        return true;
    },
    addressIsValid: function () {
        var $street = $('#street');
        var $postcode = $('#postcode');

        if ($street.val() === '') {
            $feedback.html("Enter your street");
            $feedback.show();
            return false;
        }
        if ($postcode.val() === '') {
            $feedback.html("Enter your postcode");
            $feedback.show();
            return false;
        }
        return true;
    },
    submitStaff: function (e) {
        e.preventDefault();
        if (home.personIsValid()) {

            var token = $('input:hidden[name="__RequestVerificationToken"]').val();
            var viewmodel = {
                __RequestVerificationToken: token,
                viewModel: {
                    Forename: $('#forename').val(),
                    Surname: $('#surname').val(),
                    DateOfBirth: new Date(Date.parse($('#dateOfBirth').val())).toISOString()
                }
            }

            $.ajax({
                type: 'POST',
                url: 'Home/CreateStaff',
                async: true,
                data: viewmodel,
                success: function (html, status, xhr) {
                    $('#pageContainer').html(html);
                }
            });
        }
    },
    submitClient: function (e) {
        e.preventDefault();
        if (home.personIsValid() && home.addressIsValid()) {

            var token = $('input:hidden[name="__RequestVerificationToken"]').val();
            var viewmodel = {
                __RequestVerificationToken: token,
                viewModel: {
                    Forename: $('#forename').val(),
                    Surname: $('#surname').val(),
                    DateOfBirth: new Date(Date.parse($('#dateOfBirth').val())).toISOString(),
                    Street: $('#street').val(),
                    Postcode: $('#postcode').val()
                }
            }

            $.ajax({
                type: 'POST',
                url: 'Home/CreateClient',
                async: true,
                data: viewmodel,
                success: function (html, status, xhr) {
                    $('#pageContainer').html(html);
                }
            });
        }
    }
}