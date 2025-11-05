var table;

const LoadDataTable = (tableId, pageLength, ajaxConfig, columnConfig) => {
    table = $('#' + tableId).DataTable({
        processing: true,
        destroy: false,
        scrollY: "369px",
        select: true,
        searching: true,
        sAjaxDataProp: "data",
        ordering: true,
        buttons: [
            { extend: 'print', class: 'buttons-print' },        // Linha alterada
            { extend: 'pdf', class: 'buttons-pdf' },          // Linha alterada
            { extend: 'excel', class: 'buttons-excel' },        // Linha alterada    
            { extend: 'csv', class: 'buttons-csv' }           // Linha alterada
        ],
        layout: {
            topEnd: {
                search: {
                    placeholder: 'Pelo CPF, ou Nome...'
                }
            }
        },
        info: false,
        language: {
            decimal: ",",
            thousands: "."
        },
        pagingType: "full_numbers",
        language: {
            "url": "/js/Portuguese.json"
        },
        sPaginationType: "bootstrap",
        contentType: "application/json; charset=utf-8",
        aLengthMenu: [[pageLength, 10, 20, 100, -1],
        [pageLength, 10, 20, 100, "Todos"]],
        pageLength: pageLength,
        lengthChange: true,
        ajax: ajaxConfig,
        columns: columnConfig,
        "columnDefs": [{
            "className": "small",
            "targets": "_all"
        }]
    });
}

$('#btnExcel').on('click', function () {
    table.button('.buttons-excel').trigger();
});

$('#btnPrint').on('click', function () {
    table.button('.buttons-print').trigger();
});

$('#btnCsv').on('click', function () {
    table.button('.buttons-csv').trigger();
});

$('#btnPdf').on('click', function () {
    table.button('.buttons-pdf').trigger();
});

// Funções adicionadas 

// Remover qq caractere diferente de número
function removeNonNumeric(str) {
    return str.replace(/\D/g, '');
}

// Validação do CPF
function validaCPF(cpf) {
    cpf = removeNonNumeric(cpf);
    if (cpf.length !== 11) return false;

    let soma = 0;
    let resto;
    if (/^(\d)\1{10}$/.test(cpf)) return false;

    for (let i = 1; i <= 9; i++) soma += parseInt(cpf.substring(i - 1, i)) * (11 - i);
    resto = (soma * 10) % 11;
    if ((resto === 10) || (resto === 11)) resto = 0;
    if (resto !== parseInt(cpf.substring(9, 10))) return false;

    soma = 0;
    for (let i = 1; i <= 10; i++) soma += parseInt(cpf.substring(i - 1, i)) * (12 - i);
    resto = (soma * 10) % 11;
    if ((resto === 10) || (resto === 11)) resto = 0;
    if (resto !== parseInt(cpf.substring(10, 11))) return false;

    return true;
}

function cleanCurrency(valor) {
    // Remove o símbolo "R$"
    valor = valor.replace("R$", "");

    // Remove pontos e vírgulas
    valor = valor.replace(/\./g, "").replace(/\,/g, ".");

    // Remove espaços em branco extras (caso existam)
    valor = valor.trim();

    return valor;
}

// Configuração básica da Notify.js
$.notify.defaults({
    position: 'bottom right',
    autoHide: true,
    autoHideDelay: 8000
});
