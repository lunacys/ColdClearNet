﻿using System.Runtime.InteropServices;

namespace ColdClearNet;

internal static class ColdClearInterop
{
    public const string DllName = "cold_clear";


    [DllImport(DllName, EntryPoint = "cc_launch_async")]
    public static extern ColdClearHandle LaunchAsync(Options options, Weights weights, BookHandle book, Piece[] queue, uint count);

    [DllImport(DllName, EntryPoint = "cc_launch_with_board_async")]
    public static extern ColdClearHandle LaunchWithBoardAsync(Options options, Weights weights, BookHandle book,
        byte[] field, uint bag_remain, ref Piece hold, [MarshalAs(UnmanagedType.U1)] bool b2b, uint combo, Piece[] queue,
        uint count);
    
    [DllImport(DllName, EntryPoint = "cc_destroy_async")]
    public static extern void DestroyAsync(IntPtr bot);

    [DllImport(DllName, EntryPoint = "cc_reset_async")]
    public static extern void ResetAsync(ColdClearHandle bot, byte[] field, [MarshalAs(UnmanagedType.U1)] bool b2b, uint combo);

    [DllImport(DllName, EntryPoint = "cc_add_next_piece_async")]
    public static extern void AddNextPieceAsync(ColdClearHandle bot, Piece piece);

    [DllImport(DllName, EntryPoint = "cc_request_next_move")]
    public static extern void RequestNextMove(ColdClearHandle bot, uint incoming);

    [DllImport(DllName, EntryPoint = "cc_poll_next_move")]
    public static extern BotPollStatus PollNextMove(ColdClearHandle bot, out Move move, [In, Out] PlanPlacement[] plan, ref uint plan_length);

    [DllImport(DllName, EntryPoint = "cc_block_next_move")]
    public static extern BotPollStatus BlockNextMove(ColdClearHandle bot, out Move move, [In, Out] PlanPlacement[] plan, ref uint plan_length);
    
    [DllImport(DllName, EntryPoint = "cc_default_options")]
    public static extern void DefaultOptions(out Options options);
    
    [DllImport(DllName, EntryPoint = "cc_default_weights")]
    public static extern void DefaultWeights(out Weights weights);
    
    [DllImport(DllName, EntryPoint = "cc_fast_weights")]
    public static extern void FastWeights(out Weights weights);

    [DllImport(DllName, EntryPoint = "cc_load_book_from_file")]
    public static extern BookHandle LoadBookFromFile([MarshalAs(UnmanagedType.LPStr)] string path);

    [DllImport(DllName, EntryPoint = "cc_load_book_from_memory")]
    public static extern BookHandle LoadBookFromMemory(byte[] data, uint length);
    
    [DllImport(DllName, EntryPoint = "cc_destroy_book")]
    public static extern void DestroyBook(IntPtr book);

}