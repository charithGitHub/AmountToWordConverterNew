var converter = (function () {
    function _initEvent() {       

        $('#tfn_validator').submit(function (e) {
            e.preventDefault();
            _reset();

            if ($('#name').val() == '' || $('#amount').val() == '') {
                alert("Name and Amount is required.");
            }

            var isValid = $('#amount').val().search(/^\$?\d+(,\d{3})*(\.\d*)?$/) >= 0;
            if (isValid) {                
                _ConvertAmountToWord($('#name').val(), $('#amount').val().replace(/[\$,]/g, ''));
            } else {
                alert("Amount is Invalid");
            }
            
        });
    };

    function _reset() {
        $('.form-group').removeClass('has-success');
        $('.form-group').removeClass('has-error');
        $('#result').removeClass('bg-success');
        $('#result').removeClass('bg-danger');
    }

    function _doError(message) {
        $('.form-group').addClass('has-error');
        $('#result').addClass('bg-danger').text(message).show();
        return false;
    };

    function _doSuccess(message) {
        $('#output').show();
        $('.form-group').addClass('has-success');
        //$('#result').addClass('bg-success').text(message).show();
        $('#inputName').text($('#name').val());
        $('#outputName').text($('#name').val());
        $('#inputAmount').text($('#amount').val());
        $('#outputAmount').text(message);
        
        return true;
    }

   
    //API call to validate app and convert the amount to word
    function _ConvertAmountToWord(name,amount) {
        var _url = 'http://localhost:49750/api/AmountInWords/Post/';
        var _getIpUrl = 'https://api.ipify.org/?format=json';
        var _userIp = '';

        $.getJSON("https://api.ipify.org/?format=json", function (e) {
            _userIp = e.ip;

            var amountDetails = {
                Name: name,
                Amount: amount,
                Currency: '',
                Language: '',
                Requester: _userIp,
                AppCode: 'APPAIW'
            };

            $.ajax({
                url: _url,
                async: false,
                data: JSON.stringify(amountDetails),
                dataType: "json",
                type: "POST",
                contentType: "application/json",
                success: function (jdata) {
                    debugger;
                    if (jdata.ValidationStatus == 1) {
                        _doSuccess(jdata.Words);
                    } else {
                        _doError(jdata.ErrorMessage);
                    }
                    u.log('Success: ' + _url);

                },
                error: function (err) {
                    u.log('Error' + ' (' + err.status + '-' + err.statusText + ': ' + _url + ') - ' + err.responseText);
                }
            });
        });
    }
    
    return {
        Start: function () {
            _initEvent();
        }
    }

})();

$(document).ready(function () {
    converter.Start();
});