

        $(document).ready(function ()
        {
            $("#PhoneNumber").inputmask("mask", { "mask": "(99) 9999-99999" });
            $("#CellPhoneNumber").inputmask("mask", { "mask": "(99) 9999-99999" });
            $("#Cpf").inputmask("mask", { "mask": "999.999.999-99" }, {reverse:true});
            $("#Cep").inputmask("mask", { "mask": "99999-999" });
            $("#BirthDate").inputmask("mask", { "mask": "99/99/9999" });

        });
