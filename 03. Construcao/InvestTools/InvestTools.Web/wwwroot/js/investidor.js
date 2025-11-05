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
                    return '<a href="#" data-id="' + row.codigo + '" class="editBtn"><img src="/img/Open-Button.png"  title="Abrir/Editar" alt="Editar"  width="24" height="24"></a>&nbsp&nbsp&nbsp' +
                        '<a href="#" data-id="' + row.codigo + '" class="deleteBtn"><img src="/img/Delete-Button.png" title="Eliminar" alt="Excluir" width="24" height="24"></a>';
                    // '<button class="btn btn-outline-primary btn-sm editBtn" data-id="' + row.id + '">Edit</button>' +
                    // '<button class="btn btn-outline-danger btn-sm deleteBtn" data-id="' + row.id + '">Delete</button>' +                        
                }
            }
        ],
    );

    var placeHolderElement = $("#modalContainer");

    placeHolderElement.on('click', '[data-action="save"]', function (event) {
        var url = '/investidorAPI/api/v1';

        var method = $('#investidorId').val().trim() === '' ? 'POST' : 'PUT';

        var sendInfo = {
            codigo: $('#investidorId').val().trim() === '' ? null : $('#investidorId').val(),
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
                // alert('Investidor incluido com sucesso!!!');
                $.notify('Investidor incluido com sucesso!!!', 'success');
                $('#formModal').modal('hide');
                $('#investidorTable').DataTable().ajax.reload();
            },
            error: function (request, status, error) {
                // alert(request.responseText);
                $.notify(request.responseText, 'error');

            }
        });
    });


    // Adiciona novo cliente pelo click do botão
    $('#btnAdd').click(function () {

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


        });


    });

    // Save o cliente pelo click do botão
    $('#btnSave').click(function () {
        if (!validaCPF($('#cpf').val())) {
            alert('CPF inválido. Verifique o número digitado.');
            $('#cpf').focus();

            return;
        }

        var url = '/investidorAPI/api/v1';

        var method = $('#investidorId').val().trim() === '' ? 'POST' : 'PUT';

        var sendInfo = {
            codigo: $('#investidorId').val().trim() === '' ? null : $('#investidorId').val(),
            cpf: removeNonNumeric($('#cpf').val()),
            nome: $('#nome').val(),
            dataNascimento: $('#dataNascimento').val(),
            email: $('#email').val(),
            renda: cleanCurrency($('#salario').val()),
            aporteMensal: cleanCurrency($('#salario').val())
        };

        $.ajax({
            url: url,
            type: method,
            data: JSON.stringify(sendInfo),
            contentType: "application/json; charset=utf-8",
            success: function () {
                alert('Investidor incluido com sucesso!!!');
                $('#formModal').modal('hide');
                $('#investidorTable').DataTable().ajax.reload();
            },
            error: function (request, status, error) {
                alert(request.responseText);
            }
        });
    });

});
