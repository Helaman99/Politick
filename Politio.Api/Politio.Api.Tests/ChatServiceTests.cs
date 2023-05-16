using Microsoft.VisualStudio.TestTools.UnitTesting;
using Politio.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politio.Api.Tests;

[TestClass]
public class ChatServiceTests
{
    private ChatService? _chatService;
    [TestMethod]
    public void Create_ChatService_Success()
    {
        _chatService = new();

        Assert.IsNotNull(_chatService);
    }
    [TestMethod]
    public void GetRoomId_OnePlayer_ReturnsNextRoomId()
    {
        _chatService = new();

        string actual = _chatService.GetRoomId(1, 1, 1);

        Assert.AreEqual("1", actual);
    }

    [TestMethod]
    public void GetRoomId_TwoPlayers_SameTopicDifferentSide_ReturnsSameRoomId()
    {
        _chatService = new();

        string player1Room = _chatService.GetRoomId(1, 1, 1);
        string player2Room = _chatService.GetRoomId(2, 1, 0);

        Assert.AreEqual(player1Room, player2Room);
    }

    [TestMethod]
    public void GetRoomId_TwoPlayers_SameTopicAndSide_ReturnsDifferentRoomId()
    {
        _chatService = new();

        string player1Room = _chatService.GetRoomId(1, 1, 1);
        string player2Room = _chatService.GetRoomId(2, 1, 1);

        Assert.AreNotEqual(player1Room, player2Room);
    }

    [TestMethod]
    public void GetRoomId_TwoPlayers_DifferentTopicSameSide_ReturnsDifferentRoomId()
    {
        _chatService = new();

        string player1Room = _chatService.GetRoomId(1, 0, 1);
        string player2Room = _chatService.GetRoomId(2, 1, 1);

        Assert.AreNotEqual(player1Room, player2Room);
    }

    [TestMethod]
    public void GetRoomId_ThreePlayers_SameTopicDifferentSide_ReturnsDifferentRoomIdForLastPlayer()
    {
        _chatService = new();

        string player1Room = _chatService.GetRoomId(1, 0, 0);
        string player2Room = _chatService.GetRoomId(2, 0, 1);
        string player3Room = _chatService.GetRoomId(3, 0, 0);

        Assert.AreEqual(player1Room, player2Room);
        Assert.AreNotEqual(player1Room, player3Room);
        Assert.AreNotEqual(player2Room, player3Room);
    }

    [TestMethod]
    public void GetRoomId_GivenManyPlayers_AssignsCorrectRooms()
    {
        _chatService = new();

        string player1Room = _chatService.GetRoomId(1, 0, 0);
        Assert.AreEqual("1", player1Room);

        string player2Room = _chatService.GetRoomId(2, 0, 0);
        Assert.AreEqual("2", player2Room);

        string player3Room = _chatService.GetRoomId(3, 0, 1);
        Assert.AreEqual("1", player3Room);

        string player4Room = _chatService.GetRoomId(4, 0, 0);
        Assert.AreEqual("3", player4Room);

        string player5Room = _chatService.GetRoomId(5, 0, 1);
        Assert.AreEqual("2", player5Room);

        string player6Room = _chatService.GetRoomId(6, 1, 0);
        Assert.AreEqual("4", player6Room);

        string player7Room = _chatService.GetRoomId(7, 1, 1);
        Assert.AreEqual("4", player7Room);

        string player8Room = _chatService.GetRoomId(8, 1, 1);
        Assert.AreEqual("5", player8Room);

        string player9Room = _chatService.GetRoomId(9, 0, 1);
        Assert.AreEqual("3", player9Room);

        string player10Room = _chatService.GetRoomId(10, 1, 0);
        Assert.AreEqual("5", player10Room);
    }

    [TestMethod]
    public void AddPlayerToRoom_GivenOneValidRoomId_Returns1()
    {
        _chatService = new();

        string player1Room = _chatService.GetRoomId(1, 0, 0);
        
        Assert.IsTrue(_chatService.AddPlayerToRoom("ConnID", player1Room) == 1);
    }

    [TestMethod]
    public void AddPlayerToRoom_GivenInvalidRoomId_Returns0()
    {
        _chatService = new();

        Assert.IsTrue(_chatService.AddPlayerToRoom("ConnID", "1") == 0);
    }

    [TestMethod]
    public void AddPlayerToRoom_GivenFullRoom_CantAddPlayerToRoom()
    {
        _chatService = new();

        string player1Room = _chatService.GetRoomId(1, 0, 0);
        string player2Room = _chatService.GetRoomId(2, 0, 1);

        _chatService.AddPlayerToRoom("ConnID", player1Room);
        _chatService.AddPlayerToRoom("ConnID", player2Room);

        Assert.IsTrue(_chatService.AddPlayerToRoom("ConnID", (int.Parse(player2Room) - 1).ToString()) == 0);
    }

    [TestMethod]
    public void DeleteRoom_GivenExistingRoom_ReturnsTrue()
    {
        _chatService = new();

        _chatService.GetRoomId(1, 0, 0);

        Assert.IsTrue(_chatService.DeleteRoom(1));
    }

    [TestMethod]
    public void DeleteRoom_GivenNonexistentRoom_ReturnsFalse()
    {
        _chatService = new();

        Assert.IsFalse(_chatService.DeleteRoom(1));
    }

    [TestMethod]
    public void ValidateConnection_ValidIdSendsMessage_ReturnsTrue()
    {
        _chatService = new();

        string player1RoomId = _chatService.GetRoomId(1, 0, 0);
        string player2RoomId = _chatService.GetRoomId(2, 0, 1);
        string player1ConnId = "Player1ConnId";
        string player2ConnId = "Player2ConnId";
        _chatService.AddPlayerToRoom(player1ConnId, player1RoomId);
        _chatService.AddPlayerToRoom(player2ConnId, player2RoomId);

        _chatService.StartRoom(player1RoomId);

        Assert.IsTrue(_chatService.ValidateConnection(player1RoomId, player1ConnId));
        Assert.IsTrue(_chatService.ValidateConnection(player2RoomId, player2ConnId));
    }

    [TestMethod]
    public void ValidateConnection_InvalidIdSendsMessage_ReturnsFalse()
    {
        _chatService = new();

        string player1RoomId = _chatService.GetRoomId(1, 0, 0);
        string player2RoomId = _chatService.GetRoomId(2, 0, 1);
        string player1ConnId = "Player1ConnId";
        string player2ConnId = "Player2ConnId";
        _chatService.AddPlayerToRoom(player1ConnId, player1RoomId);
        _chatService.AddPlayerToRoom(player2ConnId, player2RoomId);

        _chatService.StartRoom(player1RoomId);

        Assert.IsFalse(_chatService.ValidateConnection("FakeConnId", player1RoomId));
        Assert.IsFalse(_chatService.ValidateConnection("FakeConnId", player2RoomId));
    }
}