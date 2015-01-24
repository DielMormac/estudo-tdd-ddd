$(function () {
    'use strict';

    adicionaRegrasDeValidacaoCustomizadas();

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
    
    function adicionaRegrasDeValidacaoCustomizadas() {
        //regras customizadas
        jQuery.validator.addMethod("aoMenosUmaAtividade", function () {
            return idsAtividadesSelecionadas().length > 0;
        }, "Selecione ao menos uma atividade");
    };

    function montaAmbienteInicial() {
        $('#formularioInscricao').show();
        $('#confirmaDadosInscricao').hide();
        $('#containerAtividadesSelecionadas').hide();
    }

    function consultarPacoteSelecionado() {
        //Fazendo a requisição ao servidor
        var url = window.siteRoot + 'Inscricao/ConsultarPacote?idDoPacote=' + idDoPacoteSelecionado();
        $.get(url, { idDoPacote: idDoPacoteSelecionado() })
            .done(function (pacote) {
                montaDadosPacoteSelecionado(pacote);
            })
            .fail(function () {
                montaDadosPacoteSelecionado(null);
            })
        ;
    }

    function montaDadosPacoteSelecionado(pacote) {
        //Limpa lista de atividades
        $('#atividadesSelecionadas').html('');
        $('#containerAtividadesSelecionadas').hide();
        $('#precoInscricao').text('');

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
    }

    function calcularInscricao() {
        $('#precoInscricao').text('');

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
            });
    }

    function prosseguirInscricao() {
        if (validarInscricao()) {
            $('#formularioInscricao').hide();
            $('#confirmaDadosInscricao').show();

            $("#confirmaNomeDoParticipante").text($('#nomeDoParticipante').val());
            $("#confirmaDataDeDascimentoDoParticipante").text($('#dataDeDascimentoDoParticipante').val());
            $("#confirmaTelefoneDoParticipante").text($('#telefoneDoParticipante').val());
            $("#confirmaPacoteSelecionado").text(nomeDoPacoteSelecionado());
            $("#confirmaAtividadesSelecionadas").text(nomesAtividadesSelecionadas());
        }
    }

    function validarInscricao() {
        
        $("#formularioInscricao").validate({
            rules: {
                nomeDoParticipante: {
                    required: true,
                    minlength: 5,
                    maxlength: 100
                },
                dataDeDascimentoDoParticipante: {
                    required: true,
                },
                telefoneDoParticipante: {
                    required: true,
                },
                pacoteSelecionado: {
                    required: true,
                    aoMenosUmaAtividade:true
                }
            },
            messages: {
            }
        });

        return $('#formularioInscricao').valid();
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
        var idPacoteSelecionado = $("#pacoteSelecionado option:selected").val();
        return idPacoteSelecionado != '' ? parseInt(idPacoteSelecionado) : 0;
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