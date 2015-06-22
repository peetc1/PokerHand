$(function () {

    // game board precompiled spec
    var source = $("#gameboard-template").html();
    var template = Handlebars.compile(source);

    // card object
    function Card(type, suit) {
        this.Type = type;
        this.Suit = suit;
    }

    // player object
    function Player(name) {
        this.Name = name;
        this.Hand = [];
        this.AddCardToHand = function(type, suit) {
            this.Hand.push(new Card(type, suit));
        }
        this.ClearHand = function() {
            this.Hand = [];
        }
    }

    function Gameboard(player1, player2) {
        this.Player1 = new Player(player1);
        this.Player2 = new Player(player2);
        this.Winner = {};

        this.ClearPlayerHands = function () {
            // clear player hands
            this.Player1.ClearHand();
            this.Player2.ClearHand();
        }

        this.FillGameboard = function(obj) {
            this.Player1.Hand = obj.Player1.Hand;
            this.Player2.Hand = obj.Player2.Hand;
            this.Winner = obj.Winner;
        }
    }
    
    // player names
    var play1Name = $("#Player1_Name").val();
    var play2Name = $("#Player2_Name").val();

    var gameBoard = new Gameboard(play1Name, play2Name);

    // shuffle click
    $("#shuffle").on("click", function() {
        $.ajax({
            url: "api/DeckHands/Shuffle",
            success: function (data) {
                $("#shuffle").addClass("disabled");
            },
            error: function (xhr, status, err) {
                alert("There was an error dealing");
            }
        });
    });

    // deal click
    $("#deal").on("click", function () {
        // clear hands
        gameBoard.ClearPlayerHands();

        $.ajax({
            url: "api/DeckHands/Deal",
            success: function (data) {
                // enable shuffle
                $("#shuffle").removeClass("disabled");

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


    /*

    var data = {
        "Player1": {
            "Name": "play1",
            "Hand": [
                {
                    "Type": { "Key": "2", "Value": 2 },
                    "Suit": { "Key": 1, "Value": "C" }
                },
                {
                    "Type": { "Key": "3", "Value": 3 },
                    "Suit": { "Key": 2, "Value": "D" }
                },
                {
                    "Type": { "Key": "4", "Value": 4 },
                    "Suit": { "Key": 3, "Value": "H" }
                },
                {
                    "Type": { "Key": "5", "Value": 5 },
                    "Suit": { "Key": 4, "Value": "S" }
                },
                {
                    "Type": { "Key": "6", "Value": 6 },
                    "Suit": { "Key": 1, "Value": "C" }
                }
            ]
        },
        "Player2": {
            "Name": "play2",
            "Hand": [
                {
                    "Type": { "Key": "2", "Value": 2 },
                    "Suit": { "Key": 1, "Value": "C" }
                },
                {
                    "Type": { "Key": "3", "Value": 3 },
                    "Suit": { "Key": 2, "Value": "D" }
                },
                {
                    "Type": { "Key": "4", "Value": 4 },
                    "Suit": { "Key": 3, "Value": "H" }
                },
                {
                    "Type": { "Key": "5", "Value": 5 },
                    "Suit": { "Key": 4, "Value": "S" }
                },
                {
                    "Type": { "Key": "6", "Value": 6 },
                    "Suit": { "Key": 1, "Value": "C" }
                }
            ]
        }
    };

    */
});