namespace Bai02InterfaceSort;

public static class BoSapXep
{
    public static void SapXep<T>(T[] mang)
        where T : IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(mang);

        // Duyet tung vi tri trong mang.
        for (int i = 0; i < mang.Length - 1; i++)
        {
            // Gia su phan tu tai i la phan tu nho nhat.
            int viTriNhoNhat = i;

            // Tim phan tu nho nhat trong doan i + 1 den cuoi.
            for (int j = i + 1; j < mang.Length; j++)
            {
                // CompareTo nho hon 0 co nghia
                // mang[j] dung truoc mang[viTriNhoNhat].
                if (mang[j].CompareTo(
                    mang[viTriNhoNhat]
                ) < 0)
                {
                    viTriNhoNhat = j;
                }
            }

            // Neu tim thay phan tu nho hon thi doi cho.
            if (viTriNhoNhat != i)
            {
                HoanVi(
                    ref mang[i],
                    ref mang[viTriNhoNhat]
                );
            }
        }
    }

    private static void HoanVi<T>(
        ref T a,
        ref T b
    )
    {
        T tam = a;
        a = b;
        b = tam;
    }
}