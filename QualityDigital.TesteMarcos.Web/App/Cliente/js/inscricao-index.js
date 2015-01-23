$(function () {
    'use strict';

    //Monta ambiente inicial do formulário
    montaAmbienteInicial();

    //Instrumenta o evento 'change' do dropdown de pacote selecionado
    $('#pacoteSelecionado').change(function () {
        consultarPacoteSelecionado();
    });
    
    //Instrumenta o evento 'change' dos checkboxes de atividade
    $('body').on('change', '#formularioInscricao #atividadesSelecionadas input[type="checkbox"]', function () {
        calcularInscricao();
    });
    
    function montaAmbienteInicial() {
        $('#containerAtividadesSelecionadas').hide();
        $('#containerPrecoInscricao').hide();
    }
    
    function consultarPacoteSelecionado() {
        //Fazendo a requisição ao servidor
        var url = window.siteRoot + 'Inscricao/ConsultarPacote?idDoPacote=' + idDoPacoteSelecionado();
        $.get(url, { idDoPacote: idDoPacoteSelecionado() })
            .done(function (pacote) {
                montaDadosPacoteSelecionado(pacote);
            });
    }
    
    function montaDadosPacoteSelecionado(pacote) {
        //Limpa lista de atividades
        $('#atividadesSelecionadas').html('');
        $('#containerAtividadesSelecionadas').hide();

        //Adiciona atividades
        if (pacote !== null && pacote !== undefined) {
            
            $('#containerAtividadesSelecionadas').show();

            var atividadeIndex = 0;
            pacote.Atividades.forEach(function (item) {
                var nomeCheckBoxAtividade = 'atividadesSelecionadas[' + atividadeIndex + ']';
                var checkBoxDaAtividade = '<label class="checkbox" for="' + nomeCheckBoxAtividade + '"> '
                    + '<input type="checkbox" name="' + nomeCheckBoxAtividade + '" value="' + item.Id + '"/><span>' + item.Nome + '</span></label>';

                $('#atividadesSelecionadas').append(checkBoxDaAtividade);

                atividadeIndex++;
            });
        }
        
        calcularInscricao();
    }

    function calcularInscricao() {
        $('#precoInscricao').text('');
        $('#containerPrecoInscricao').hide();

        //Fazendo a requisição ao servidor para calcular a inscricao
        var url = window.siteRoot + 'Inscricao/CalcularInscricao';

        $.ajax({
            url: url,
            type: "POST",
            dataType:"json",
            data: {
                pacoteSelecionado: idDoPacoteSelecionado(),
                atividadesSelecionadas: atividadesSelecionadas()
            }
        })
            .done(function(valor) {
                $('#precoInscricao').text(valor.toFixed(2).toLocaleString());
                $('#containerPrecoInscricao').show();
            });
    }

    function idDoPacoteSelecionado() {
        return parseInt($("#pacoteSelecionado option:selected").val());
    }
    
    function atividadesSelecionadas() {
        var atividades = Array();
        $('#formularioInscricao #atividadesSelecionadas input[type="checkbox"]').each(function () {
            if ($(this).is(':checked'))
                atividades.push($(this).val());
        });

        return atividades;
    }
});