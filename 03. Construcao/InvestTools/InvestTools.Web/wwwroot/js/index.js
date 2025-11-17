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

// Função inserida
$.fn.validarCampoMonetario = function( $input ){
    // Remover classes e estilos anteriores de forma garantida
    $input.removeClass('is-valid is-invalid').removeAttr('aria-invalid').css({
        'border-color': '',
        'box-shadow': ''
    });

    const minAttr = $input.attr('min');
    const maxAttr = $input.attr('max');

    const minimo = (minAttr ? parseFloat(minAttr) : -Infinity);
    const maximo = (maxAttr ? parseFloat(maxAttr) : Infinity);

    let texto = ($input.val() || '').trim();
    texto = texto.replace(/[^\d\-,.]/g, '');

    const lastComma = texto.lastIndexOf(',');
    const lastDot = texto.lastIndexOf('.');
    const lastSep = Math.max(lastComma, lastDot);

    if (lastSep !== -1) {
        let inteira = texto.slice(0, lastSep).replace(/[.,]/g, '');
        let decimal = texto.slice(lastSep + 1).replace(/[.,]/g, '');
        texto = inteira + '.' + decimal;
    } else {
        texto = texto.replace(/[.,]/g, '');
    }

    const numero = parseFloat(texto);

    if (isNaN(numero) || numero < minimo || numero > maximo) {
        // garante rejeitar qualquer is-valid residual e aplicar is-invalid
        $input.removeClass('is-valid').addClass('is-invalid').attr('aria-invalid', 'true');

        // fallback inline caso alguma regra CSS ainda sobreponha a classe
        $input.css({
            'border-color': '#dc3545',
            'box-shadow': '0 0 0 .25rem rgba(220,53,69,.25)'
        });

        return false;
    } else {
        // garante remover qualquer visual inválido e aplicar válido
        $input.removeClass('is-invalid').addClass('is-valid').removeAttr('aria-invalid');

        // limpar qualquer style inline que tenhamos setado
        $input.css({
            'border-color': '',
            'box-shadow': ''
        });

        return true;
    }
}

// Função inserida
$.fn.validarCPF = function($input) {

    // Remover status anterior
    $input.removeClass('is-valid is-invalid').removeAttr('aria-invalid').css({
        'border-color': '',
        'box-shadow': ''
    });

    let cpf = $input.val().replace(/[^\d]/g, '');

    if (cpf.length !== 11) {
        $input.removeClass('is-valid').addClass('is-invalid').attr('aria-invalid', 'true');

        // fallback inline caso alguma regra CSS ainda sobreponha a classe
        $input.css({
            'border-color': '#dc3545',
            'box-shadow': '0 0 0 .25rem rgba(220,53,69,.25)'
        });

        return false;
    }

    // Rejeita CPFs conhecidos e inválidos
    if (/^(.)\1+$/.test(cpf)) {
        $input.removeClass('is-valid').addClass('is-invalid').attr('aria-invalid', 'true');

        // fallback inline caso alguma regra CSS ainda sobreponha a classe
        $input.css({
            'border-color': '#dc3545',
            'box-shadow': '0 0 0 .25rem rgba(220,53,69,.25)'
        });

        return false;
    }

    // Cálculo dos dígitos verificadores
    let soma = 0;
    let resto;

    // Primeiro dígito
    for (let i = 1; i <= 9; i++) soma += parseInt(cpf[i - 1]) * (11 - i);
    resto = (soma * 10) % 11;
    if (resto === 10 || resto === 11) resto = 0;
    if (resto !== parseInt(cpf[9])) {
        $input.removeClass('is-valid').addClass('is-invalid').attr('aria-invalid', 'true');

        // fallback inline caso alguma regra CSS ainda sobreponha a classe
        $input.css({
            'border-color': '#dc3545',
            'box-shadow': '0 0 0 .25rem rgba(220,53,69,.25)'
        });

        return false;
    }

    // Segundo dígito
    soma = 0;
    for (let i = 1; i <= 10; i++) soma += parseInt(cpf[i - 1]) * (12 - i);
    resto = (soma * 10) % 11;
    if (resto === 10 || resto === 11) resto = 0;
    if (resto !== parseInt(cpf[10])) {
        $input.addClass('is-invalid');
        return false;
    }

    // CPF OK

    $input.removeClass('is-invalid').addClass('is-valid').removeAttr('aria-invalid');

    // limpar qualquer style inline que tenhamos setado
    $input.css({
        'border-color': '',
        'box-shadow': ''
    });

    return true;
}

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
