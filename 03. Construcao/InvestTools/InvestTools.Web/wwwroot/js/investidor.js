$(document).ready(function () {
    LoadDataTable('investidorTable',
        7,
        {
            url: '/investidorAPI/api/v1',
            type: 'GET'
        },
        [
            {
                data: 'cpf',
                width: "15%",
                center: true,
                render: function (data, type, row) {
                    if (!data) return '';
                    return data.replace(/^(\d{3})(\d{3})(\d{3})(\d{2})$/, "$1.$2.$3-$4");
                }
            },
            { data: 'nome', width: "30%" },
            { data: 'email', width: "20%" },
            {
                data: 'dataNascimento',
                width: "15%",
                render: function (data, type, row) {
                    if (!data) return '';

                    // Exibe no formato dd/MM/yyyy
                    const date = new Date(data);

                    return date.toLocaleDateString('pt-BR');
                }
            },
            {
                data: null,
                width: "20%",
                render: function (data, type, row) {
                    return '<a href="#" data-id="' + row.id + '" class="editBtn"><img src="/img/Open-Button.png"  title="Abrir/Editar" alt="Editar"  width="24" height="24"></a>&nbsp&nbsp&nbsp' +
                        '<a href="#" data-id="' + row.id + '" class="deleteBtn"><img src="/img/Delete-Button.png" title="Eliminar" alt="Excluir" width="24" height="24"></a>';
                    // '<button class="btn btn-outline-primary btn-sm editBtn" data-id="' + row.id + '">Edit</button>' +
                    // '<button class="btn btn-outline-danger btn-sm deleteBtn" data-id="' + row.id + '">Delete</button>' +                        
                }
            }
        ],
    );


    $.fn.GetModalPartial = function() {
        $.get('/Investidor/GetModalPartial').done(function (data) {
            $('#modalContainer').html(data);

            document.getElementById('investidorForm').classList.remove("was-validated");
            $('#formModal').modal('show');
            $('#investidorForm')[0].reset(); // Clear the form
            $('#formModalLabel').text('Inclusão');
            $('#btnSave').text('Salvar');
            $('#investidorId').val(''); // Clear the hidden ID field

            $("#cpf").mask("000.000.000-00");
            $('#aporteMensal').maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',',symbolStay: true,  affixesStay: true });
            $('#renda').maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',',symbolStay: true,  affixesStay: true });

            // Evento incluido
            $('#aporteMensal').on('focus', function() {  
                $(this).select();
            });  

            $('#renda').on('focus', function() {  
                $(this).select();
            });  

            // Função incluida
            // Função associada ao Bootstrap para fazer o efeito de validação dos campos
            (function () {
                'use strict';
                var form = document.getElementById('investidorForm');
                var button = document.getElementById('btnSave');

                button.addEventListener('click', function () {
                    if (!form.checkValidity()) {
                        form.classList.add('was-validated');
                    } else {
                        // alert('Formulário validado com sucesso!');
                        Save();
                    }
                });
            })();

                        // Evento incluido
            $('#cpf').on('blur', function () {
                $.fn.validarCPF($(this));
            });

            // Evento incluido
            $('#renda').on('blur', function () {
                $.fn.validarCampoMonetario($(this));
            });

            // Evento incluido
            $('#aporteMensal').on('blur', function () {
                $.fn.validarCampoMonetario($(this));
            });


            // Evento Incluido
            document.querySelectorAll('.remove-acento').forEach(function (input) {
                input.addEventListener('input', function (event) {
                    let texto = event.target.value;

                    // Substituir acentos e "ç"
                    texto = texto.normalize("NFD").replace(/[\u0300-\u036f]/g, ""); // Remove acentos
                    texto = texto.replace(/ç/g, 'c').replace(/Ç/g, 'C'); // Substitui "ç" por "c"

                    // Forçar texto em maiúsculas
                    // texto = texto.toUpperCase();

                    event.target.value = texto;
                });
            });

            // Evento incluido
            document.querySelectorAll(".maiusculo").forEach( function( input ) {
                input.addEventListener('blur', function(){
                    input.value = input.value.toUpperCase();
                });
            });

            // Evento incluido
            document.querySelectorAll(".minusculo").forEach( function( input ) {
                input.addEventListener('blur', function(){
                    input.value = input.value.toLowerCase();
                });
            });
        }); 

    };

    // Adiciona novo investidor pelo click do botão
    $('#btnAdd').click(function () {
        $(document).GetModalPartial();
    });


    $('#investidorTable').on('click', '.editBtn', function(event) {
        event.preventDefault(); // Evita o redirecionamento automático
        var investidorId = $(this).data('id');

        $(document).GetModalPartial();

        $.ajax({
            url: '/investidorAPI/api/v1/' + investidorId, // Replace with your ASP.NET API endpoint
            type: 'GET',
            datatype: 'json',
            success: function (data) {
                $('#formModal').modal('show');
                $('#formModalLabel').text('Alteração');
                $('#btnSave').text('Salvar');
                $('#investidorId').val(data.data.id);
                $('#cpf').val(data.data.cpf).trigger('input');
                $('#nome').val(data.data.nome);
                $('#email').val(data.data.email);
                $('#aporteMensal').val(Number(data.data.aporteMensal).toFixed(2).replace(/\./g,",")).maskMoney('mask');
                $('#renda').val(Number(data.data.renda).toFixed(2).replace(/\./g,",")).maskMoney('mask');
                $('#dataNascimento').val(data.data.dataNascimento.substring(0,10));

            },
            error: function (request, status, error) {
                $.notify("Ocorreu o seguinte erro: \r\n\r\n" + request.responseText, 'error');
            }
        });


    });

    // Função inserida
    var modalConfirmacao = new bootstrap.Modal(document.getElementById('confirmacaoModal'));

    // Delete Customer Button Click
    $('#investidorTable tbody').on('click', '.deleteBtn', function () {
        $('#id-delete').val($(this).data('id'));

        $('#modalMensagem').text("Deseja realmente eliminar este investidor?");
        
        modalConfirmacao.show();
    });

    // Função inserida
    $('#confirmarEnvio').click(function(){
        if ( $('#id-delete').val() != '' ){
            var codigo = $('#id-delete').val();

            modalConfirmacao.hide();

            var sendInfo = {
                "Id": $('#id-delete').val()
            };


            $.ajax({
                url: '/investidorAPI/api/v1', // AQUI ENVIAR O MODEL INVESTIDOR
                type: 'DELETE',
                data: JSON.stringify( { "Id": $('#id-delete').val() } ), // JSON.stringify(sendInfo),
                contentType: "application/json; charset=utf-8",
                success: function () {
                    $('#investidorTable').DataTable().ajax.reload();
                    $.notify("Eliminação realizada com sucesso!!!", 'success');
                },
                error: function(){
                    $.notify("Ocorreu o seguinte erro: \r\n\r\n" + request.responseText, 'error');
                }
            });

            $('#id-delete').val('');
        }
    });
});

const Save = () => {
        // Trecho inserido
    let cpfValido = $.fn.validarCPF($('#cpf'));

    if (!cpfValido) {
        $('#cpf').focus();
        return; // impede submit
    }

    let houveInvalido = false;

    $('.monetario').each(function () {
        const valido = $.fn.validarCampoMonetario($(this));
        if (!valido) houveInvalido = true;
    });

    if (houveInvalido) {
        // opcional: focar no primeiro inválido
        $('.monetario.is-invalid').first().focus();
        return; // interrompe o fluxo (não salva)
    }

    // Aqui o formulário está válido — prossiga com o submit/ajax
    // Ex.: $('#investidorForm').submit();
    console.log('Formulário válido — pode salvar!');

    var url = '/investidorAPI/api/v1';


    var method = $('#investidorId').val().trim() === '' ? 'POST' : 'PUT';

    var sendInfo = {
        id: $('#investidorId').val().trim() === "" ? "0" : $('#investidorId').val(),
        cpf: removeNonNumeric($('#cpf').val()),
        nome: $('#nome').val(),
        dataNascimento: $('#dataNascimento').val(),
        email: $('#email').val(),
        renda: cleanCurrency($('#renda').val()),
        aporteMensal: cleanCurrency($('#aporteMensal').val())
    };

    $.ajax({
        url: url,
        type: method,
        data: JSON.stringify(sendInfo),
        contentType: "application/json; charset=utf-8",
        success: function () {
            if (method === 'POST') {
                $.notify('Investidor incluido com sucesso!!!', 'success');
            } else {
                $.notify('Investidor alterado com sucesso!!!', 'success');
            }
            
            $('#formModal').modal('hide');
            $('#investidorTable').DataTable().ajax.reload();
        },
        error: function (request, status, error) {
            // alert(request.responseText);
            $.notify(request.responseText, 'error');

        }
    });
};
