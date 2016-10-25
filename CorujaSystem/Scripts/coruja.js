
// Preenche Endereço /////////////////////////////////////////////////////////////////////////

$(document).ready(function () {

    function limpa_formulário_cep() {
        // Limpa valores do formulário de cep.
        $("#Address").val("");
        $("#Nhood").val("");
        $("#City").val("");
        $("#State").val("");
    }

    //Quando o campo cep perde o foco.
    $("#Cep").blur(function () {

        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#Address").val("...")
                $("#Nhood").val("...")
                $("#City").val("...")
                $("#State").val("...")


                //Consulta o webservice viacep.com.br/
                $.getJSON("//viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#Address").val(dados.logradouro);
                        $("#Nhood").val(dados.bairro);
                        $("#City").val(dados.localidade);
                        $("#State").val(dados.uf);

                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });
});

////////////////////////////////////////////////////////////////////////////////////////////


// Upload File

$body = $("Upload");
$(document).on({
    ajaxStart: function () { $body.addClass("loading"); },
    ajaxStop: function () { $body.removeClass("loading"); }
});

$(document).ready(function () {
    $("#upload").click(function () {
        var data = new FormData();

        //Add the Multiple selected files into the data object
        var files = $("#files").get(0).files;
        for (i = 0; i < files.length; i++) {
            data.append("files" + i, files[i]);
        }

        //Post the data (files) to the server
        if (files.length > 0) {
            $.ajax({
                type: 'POST',
                url: "/Home/Upload",
                data: data, 
            contentType: false,
            processData: false,
            success: function (data) {
                alert("Arquivo carregado com sucesso!");
            },
            error: function () {
                alert("Erro ao carregar arquivo!");
            },
            });
    }
    });
});



////////////////////////////////////////////////////////////////////////////////////////////