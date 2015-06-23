$(function () {

    // game board precompiled spec
    var source = $("#gameboard-template").html();
    var template = Handlebars.compile(source);

    // player object
    function Player(name) {
        this.Name = name;
        this.Hand = [];
    }

    function Gameboard(player1, player2) {
        this.Player1 = new Player(player1);
        this.Player2 = new Player(player2);
        this.Winner = null;

        this.FillGameboard = function(obj) {
            this.Player1.Hand = obj.Player1.Hand;
            this.Player2.Hand = obj.Player2.Hand;
            this.Winner = obj.GameWinner;
        }
    }
    
    // player names
    var play1Name = $("#Player1_Name").val();
    var play2Name = $("#Player2_Name").val();

    var gameBoard = new Gameboard(play1Name, play2Name);

    // shuffle click
    $("#shuffle").on("click", function () {
        // disable deal button
        $("#deal").addClass("disabled");

        $.ajax({
            url: "Game/Shuffle",
            method: "POST",
            success: function (data) {
                // disable shuffle button
                $("#shuffle").addClass("disabled");

                // enable deal button
                $("#deal").removeClass("disabled");
            },
            error: function (xhr, status, err) {
                alert("There was an error shuffling");
            }
        });
    });

    // deal click
    $("#deal").on("click", function () {
        // disable deal button
        $("#deal").addClass("disabled");

        $.ajax({
            url: "Game/Deal",
            data: "{ Player1: " + JSON.stringify(gameBoard.Player1) + ", Player2: " + JSON.stringify(gameBoard.Player2) + " }",
            contentType: "application/json; charset=UTF-8",
            method: "POST",
            success: function (data) {
                // enable shuffle button
                $("#shuffle").removeClass("disabled");

                // enable deal button
                $("#deal").removeClass("disabled");

                // update gameboard
                gameBoard.FillGameboard(data);

                // populate template
                $("#content-placeholder").html(template(gameBoard));
            },
            error: function (xhr, status, err) {
                alert("There was an error dealing");
            }
        });
    });
   
    // populate template
    $("#content-placeholder").html(template(gameBoard));
});