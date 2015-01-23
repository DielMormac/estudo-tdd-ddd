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

    //Instrumenta o evento 'click' do botão de prosseguir a inscrição
    $('#prosseguirInscricao').click(function (e) {
        e.preventDefault();
        prosseguirInscricao();
    });

    $('#alterarInscricao').click(function (e) {
        e.preventDefault();
        alterarInscricao();
    });

    $('#confirmarInscricao').click(function (e) {
        e.preventDefault();
        confirmarInscricao();
    });

    function montaAmbienteInicial() {
        $('#formularioInscricao').show();
        $('#confirmaDadosInscricao').hide();
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
                    + '<input type="checkbox" name="' + nomeCheckBoxAtividade + '" value="' + item.Id + '" data-nome="' + item.Nome + '"/><span>' + item.Nome + '</span></label>';

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
            dataType: "json",
            data: {
                pacoteSelecionado: idDoPacoteSelecionado(),
                atividadesSelecionadas: idsAtividadesSelecionadas()
            }
        })
            .done(function (valor) {
                $('#precoInscricao').text(valor.toFixed(2).toLocaleString());
                $('#containerPrecoInscricao').show();
            });
    }

    function prosseguirInscricao() {

        $('#formularioInscricao').hide();
        $('#confirmaDadosInscricao').show();

        $("#confirmaNomeDoParticipante").text($('#nomeDoParticipante').val());
        $("#confirmaDataDeDascimentoDoParticipante").text($('#dataDeDascimentoDoParticipante').val());
        $("#confirmaTelefoneDoParticipante").text($('#telefoneDoParticipante').val());
        $("#confirmaPacoteSelecionado").text(nomeDoPacoteSelecionado());
        $("#confirmaPrecoInscricao").text($('#precoInscricao').text());
        $("#confirmaAtividadesSelecionadas").text(nomesAtividadesSelecionadas());
    }

    function alterarInscricao() {
        $('#formularioInscricao').show();
        $('#confirmaDadosInscricao').hide();
    }

    function confirmarInscricao() {
        //todo: enviar a confirmação
        alert('confimação será enviada aqui!');
    }

    function idDoPacoteSelecionado() {
        return parseInt($("#pacoteSelecionado option:selected").val());
    }

    function nomeDoPacoteSelecionado() {
        return $("#pacoteSelecionado :selected").text();
    }

    function idsAtividadesSelecionadas() {
        var atividades = Array();
        $('#formularioInscricao #atividadesSelecionadas input[type="checkbox"]').each(function () {
            if ($(this).is(':checked'))
                atividades.push($(this).val());
        });

        return atividades;
    }

    function nomesAtividadesSelecionadas() {
        var atividades = Array();
        $('#formularioInscricao #atividadesSelecionadas input[type="checkbox"]').each(function () {
            if ($(this).is(':checked'))
                atividades.push($(this).attr('data-nome'));
        });

        return atividades;
    }
});