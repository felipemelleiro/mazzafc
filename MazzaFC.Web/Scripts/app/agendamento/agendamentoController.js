appmazzafc.controller("agendamentoController", ['$scope', '$window', 'agendamentoRepository', 'pacienteRepository', 'medicoRepository', function ($scope, $window, agendamentoRepository, pacienteRepository, medicoRepository) {

    $scope.dateOptions = {
        dateFormat: "dd-M-yy"
    };

    listar();

    function listar() {

        agendamentoRepository.listar().then(sucesso, fail);

        function sucesso(response) {
            $scope.listaAgendamentos = response.data;
        };

        function fail(error) {
            alert("Erro ao processar!!");
        }

    };

    function carregarPacientes() {
        pacienteRepository.listar().then(sucesso, fail);

        function sucesso(response) {
            $scope.listaPacientes = response.data;
        };

        function fail(error) {
            alert("Erro ao processar!!");
        }
    }

    function carregarMedicos() {
        medicoRepository.listar().then(sucesso, fail);

        function sucesso(response) {
            $scope.listaMedicos = response.data;
        };

        function fail(error) {
            alert("Erro ao processar!!");
        }
    }

    $scope.novo = function () {

        $scope.AgendamentoId = null;
        $scope.PacienteId = null;
        $scope.MedicoId = null;
        $scope.AgendamentoDataHora = "";
        $scope.AgendamentoComentario = "";

        carregarPacientes();
        carregarMedicos();


    };

    $scope.salvar = function () {

        var _model = {
            "AgendamentoId": $scope.AgendamentoId,
            "PacienteId": $scope.PacienteId,
            "MedicoId": $scope.MedicoId,
            "AgendamentoDataHora": $scope.AgendamentoDataHora,
            "AgendamentoComentario": $scope.AgendamentoComentario
        };

        agendamentoRepository.salvar(_model).then(sucesso, fail);

        function sucesso(response) {

            alert(response.data.Mensagem);

            listar();

            $("#modalForm").modal("hide");
        };

        function fail(error) {
            alert("Erro ao processar!!");
        };
    };

    $scope.editar = function (item) {

        console.log(item);

        carregarPacientes();
        carregarMedicos();

        $scope.AgendamentoId = item.AgendamentoId;
        $scope.PacienteId = item.Paciente.PacienteId;
        $scope.MedicoId = item.Medico.MedicoId;
        $scope.AgendamentoDataHora = item.AgendamentoDataHoraText;
        $scope.AgendamentoComentario = item.AgendamentoComentario;

        $("#modalForm").modal();
    };

    $scope.excluir = function (item) {

        agendamentoRepository.excluir(item).then(sucesso, fail);

        function sucesso(response) {

            alert(response.data.Mensagem);

            listar();
        };

        function fail(error) {
            alert("Erro ao processar!!");
        };
    };

}]);