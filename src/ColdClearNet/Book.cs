namespace ColdClearNet;

public sealed class Book : IDisposable
{
    internal IntPtr _book;

    private Book(IntPtr book)
    {
        _book = book;
    }

    public static Book LoadFromFile(string path)
    {
        var ptr = ColdClearInterop.LoadBookFromFile(path);

        if (ptr == IntPtr.Zero)
            throw new Exception("Could not read the book requested");

        return new Book(ptr);
    }


    private void ReleaseUnmanagedResources()
    {
        if (_book == IntPtr.Zero)
            return;

        ColdClearInterop.DestroyBook(_book);
        _book = IntPtr.Zero;
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    ~Book()
    {
        ReleaseUnmanagedResources();
    }
}