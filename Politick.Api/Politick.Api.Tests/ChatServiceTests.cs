using Microsoft.VisualStudio.TestTools.UnitTesting;
using Politick.Api.Data;
using Politick.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politick.Api.Tests;

[TestClass]
public class ChatServiceTests
{
    private ChatService? _chatService;
    private int OpponentIds = 0;
    private Opponent GenerateOpponent(int topic, int side)
    {
        OpponentIds++;
        return new Opponent($"email{OpponentIds}", $"avatar{OpponentIds}", $"title{OpponentIds}", topic, side, "");
    }

    [TestMethod]
    public void Create_ChatService_Success()
    {
        _chatService = new();

        Assert.IsNotNull(_chatService);
    }

    [TestMethod]
    public void AssignRoomId_GivenOpponent_ReturnsOpponentWithoutEmail()
    {
        _chatService = new();

        Assert.AreEqual("", _chatService.AssignRoomId(GenerateOpponent(1, 1)).Email);
    }

    [TestMethod]
    public void AssignRoomId_OnePlayer_ReturnsNextRoomId()
    {
        _chatService = new();

        Opponent actual = _chatService.AssignRoomId(GenerateOpponent(1, 1));

        Assert.AreEqual("1", actual.ChatRoomId);
    }

    [TestMethod]
    public void AssignRoomId_TwoPlayers_SameTopicDifferentSide_ReturnsSameRoomId()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(1, 1));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(1, 0));

        Assert.AreEqual(player1.ChatRoomId, player2.ChatRoomId);
    }

    [TestMethod]
    public void AssignRoomId_TwoPlayers_SameTopicAndSide_ReturnsDifferentRoomId()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(1, 1));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(1, 1));

        Assert.AreNotEqual(player1.ChatRoomId, player2.ChatRoomId);
    }

    [TestMethod]
    public void AssignRoomId_TwoPlayers_DifferentTopicSameSide_ReturnsDifferentRoomId()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(1, 1));

        Assert.AreNotEqual(player1.ChatRoomId, player2.ChatRoomId);
    }

    [TestMethod]
    public void AssignRoomId_TwoPlayers_DifferentTopicDifferentSide_ReturnsDifferentRoomId()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(1, 0));

        Assert.AreNotEqual(player1.ChatRoomId, player2.ChatRoomId);
    }

    [TestMethod]
    public void AssignRoomId_ThreePlayers_SameTopicDifferentSide_ReturnsDifferentRoomIdForLastPlayer()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        Opponent player3 = _chatService.AssignRoomId(GenerateOpponent(0, 0));

        Assert.AreEqual(player1.ChatRoomId, player2.ChatRoomId);
        Assert.AreNotEqual(player1.ChatRoomId, player3.ChatRoomId);
        Assert.AreNotEqual(player2.ChatRoomId, player3.ChatRoomId);
    }

    [TestMethod]
    public void AssignRoomId_GivenManyPlayers_AssignsCorrectRooms()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Assert.AreEqual("1", player1.ChatRoomId);

        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Assert.AreEqual("2", player2.ChatRoomId);

        Opponent player3 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        Assert.AreEqual("1", player3.ChatRoomId);

        Opponent player4 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Assert.AreEqual("3", player4.ChatRoomId);

        Opponent player5 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        Assert.AreEqual("2", player5.ChatRoomId);

        Opponent player6 = _chatService.AssignRoomId(GenerateOpponent(1, 0));
        Assert.AreEqual("4", player6.ChatRoomId);

        Opponent player7 = _chatService.AssignRoomId(GenerateOpponent(1, 1));
        Assert.AreEqual("4", player7.ChatRoomId);

        Opponent player8 = _chatService.AssignRoomId(GenerateOpponent(1, 1));
        Assert.AreEqual("5", player8.ChatRoomId);

        Opponent player9 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        Assert.AreEqual("3", player9.ChatRoomId);

        Opponent player10 = _chatService.AssignRoomId(GenerateOpponent(1, 0));
        Assert.AreEqual("5", player10.ChatRoomId);
    }

    [TestMethod]
    public void AddPlayerToRoom_AddingOnePlayer_Returns1()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        
        Assert.IsTrue(_chatService.AddPlayerToRoom("ConnID", player1.ChatRoomId) == 1);
    }

    [TestMethod]
    public void AddPlayerToRoom_AddingTwoPlayers_Returns2()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(0, 1));

        _chatService.AddPlayerToRoom("ConnID", player1.ChatRoomId);
        
        Assert.IsTrue(_chatService.AddPlayerToRoom("ConnID", player2.ChatRoomId) == 2);
    }

    [TestMethod]
    public void AddPlayerToRoom_GivenInvalidRoomId_Returns0()
    {
        _chatService = new();

        Assert.IsTrue(_chatService.AddPlayerToRoom("ConnID", "1") == 0);
    }


    [TestMethod]
    public void AddPlayerToRoom_AddingPlayerToFullRoom_Returns0()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(0, 1));

        _chatService.AddPlayerToRoom("ConnID", player1.ChatRoomId);
        _chatService.AddPlayerToRoom("ConnID", player2.ChatRoomId);

        Assert.IsTrue(_chatService.AddPlayerToRoom("ConnID", (int.Parse(player2.ChatRoomId) - 1).ToString()) == 0);
    }

    [TestMethod]
    public void ValidateConnection_ValidIdSendsMessage_ReturnsTrue()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        string player1ConnId = "Player1ConnId";
        string player2ConnId = "Player2ConnId";
        _chatService.AddPlayerToRoom(player1ConnId, player1.ChatRoomId);
        _chatService.AddPlayerToRoom(player2ConnId, player2.ChatRoomId);

        _chatService.StartRoom(player1.ChatRoomId);

        Assert.IsTrue(_chatService.ValidateConnection(player1.ChatRoomId, player1ConnId));
        Assert.IsTrue(_chatService.ValidateConnection(player2.ChatRoomId, player2ConnId));
    }

    [TestMethod]
    public void ValidateConnection_InvalidIdSendsMessage_ReturnsFalse()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        string player1ConnId = "Player1ConnId";
        string player2ConnId = "Player2ConnId";
        _chatService.AddPlayerToRoom(player1ConnId, player1.ChatRoomId);
        _chatService.AddPlayerToRoom(player2ConnId, player2.ChatRoomId);

        _chatService.StartRoom(player1.ChatRoomId);

        Assert.IsFalse(_chatService.ValidateConnection("FakeConnId", player1.ChatRoomId));
        Assert.IsFalse(_chatService.ValidateConnection("FakeConnId", player2.ChatRoomId));
    }

    [TestMethod]
    public void StartRoom_GivenValidRoomId_ReturnsTrue()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        string player1ConnId = "Player1ConnId";
        string player2ConnId = "Player2ConnId";
        _chatService.AddPlayerToRoom(player1ConnId, player1.ChatRoomId);
        _chatService.AddPlayerToRoom(player2ConnId, player2.ChatRoomId);

        Assert.IsTrue(_chatService.StartRoom(player1.ChatRoomId));
    }

    [TestMethod]
    public void StartRoom_GivenInvalidRoomId_ReturnsFalse()
    {
        _chatService = new();

        Assert.IsFalse(_chatService.StartRoom("InvalidRoomId"));
    }

    [TestMethod]
    public void EndGame_GivenValidRoomId_ReturnsTrue()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        string player1ConnId = "Player1ConnId";
        string player2ConnId = "Player2ConnId";
        _chatService.AddPlayerToRoom(player1ConnId, player1.ChatRoomId);
        _chatService.AddPlayerToRoom(player2ConnId, player2.ChatRoomId);

        _chatService.StartRoom(player1.ChatRoomId);

        Assert.IsTrue(_chatService.EndGame(player1.ChatRoomId));
    }

    [TestMethod]
    public void EndGame_GivenInvalidRoomId_ReturnsFalse()
    {
        _chatService = new();

        Assert.IsFalse(_chatService.EndGame("InvalidRoomId"));
    }

    [TestMethod]
    public void DisconnectRoom_GivenConnIdForRoom_ReturnsThatRoomsId()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        string player1ConnId = "Player1ConnId";
        string player2ConnId = "Player2ConnId";
        _chatService.AddPlayerToRoom(player1ConnId, player1.ChatRoomId);
        _chatService.AddPlayerToRoom(player2ConnId, player2.ChatRoomId);

        Assert.AreEqual(_chatService.DisconnectRoom(player1ConnId), player1.ChatRoomId);
    }

    [TestMethod]
    public void DisconnectRoom_GivenConnIdForRoomInProgress_ReturnsThatRoomsId()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        Opponent player2 = _chatService.AssignRoomId(GenerateOpponent(0, 1));
        string player1ConnId = "Player1ConnId";
        string player2ConnId = "Player2ConnId";
        _chatService.AddPlayerToRoom(player1ConnId, player1.ChatRoomId);
        _chatService.AddPlayerToRoom(player2ConnId, player2.ChatRoomId);

        _chatService.StartRoom(player1.ChatRoomId);

        Assert.AreEqual(_chatService.DisconnectRoom(player1ConnId), player1.ChatRoomId);
    }

    [TestMethod]
    public void DisconnectRoom_GivenInvaledConnId_ReturnsNegativeOne()
    {
        _chatService = new();

        Assert.AreEqual(_chatService.DisconnectRoom("InvalidConnId"), "-1");
    }

    [TestMethod]
    public void GetOpponent_GivenOpponent_ReturnedOpponentHasNoEmail()
    {
        _chatService = new();

        Opponent player1 = GenerateOpponent(0, 0);
        Opponent player2 = GenerateOpponent(0, 1);
        _chatService.AssignRoomId(player1);
        _chatService.AssignRoomId(player2);
        string player1ConnId = "Player1ConnId";
        string player2ConnId = "Player2ConnId";
        _chatService.AddPlayerToRoom(player1ConnId, player1.ChatRoomId);
        _chatService.AddPlayerToRoom(player2ConnId, player2.ChatRoomId);

        _chatService.StartRoom(player1.ChatRoomId);

        Opponent opponent = _chatService.GetOpponent(player1);

        Assert.AreEqual("", opponent.Email);
    }

    [TestMethod]
    public void GetOpponent_GivenOnePlayer_ReturnsTheOtherPlayer()
    {
        _chatService = new();

        Opponent player1 = GenerateOpponent(0, 0);
        Opponent player2 = GenerateOpponent(0, 1);
        _chatService.AssignRoomId(player1);
        _chatService.AssignRoomId(player2);
        string player1ConnId = "Player1ConnId";
        string player2ConnId = "Player2ConnId";
        _chatService.AddPlayerToRoom(player1ConnId, player1.ChatRoomId);
        _chatService.AddPlayerToRoom(player2ConnId, player2.ChatRoomId);

        _chatService.StartRoom(player1.ChatRoomId);

        Opponent opponent = _chatService.GetOpponent(player1);

        Assert.AreEqual(player2.Title, opponent.Title);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetOpponent_GivenNullPlayer_ThrowsException()
    {
        _chatService = new();

        _chatService.GetOpponent(null!);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void GetOpponent_GivenRoomNotStarted_ThrowsException()
    {
        _chatService = new();

        Opponent player1 = _chatService.AssignRoomId(GenerateOpponent(0, 0));
        string player1ConnId = "Player1ConnId";
        _chatService.AddPlayerToRoom(player1ConnId, player1.ChatRoomId);

        _chatService.GetOpponent(player1);
    }
}