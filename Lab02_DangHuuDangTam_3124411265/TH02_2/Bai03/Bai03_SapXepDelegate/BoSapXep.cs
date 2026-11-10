namespace Bai03DelegateSort;

public static class BoSapXep
{
    public static void SapXep<T>(
        T[] mang,
        SoSanh<T> hamSoSanh
    )
    {
        ArgumentNullException.ThrowIfNull(mang);
        ArgumentNullException.ThrowIfNull(hamSoSanh);

        // Su dung thuat toan Selection Sort.
        for (int i = 0; i < mang.Length - 1; i++)
        {
            // Gia su phan tu tai i dung dau
            // trong phan mang chua sap xep.
            int viTriPhuHop = i;

            for (int j = i + 1; j < mang.Length; j++)
            {
                // Neu mang[j] dung truoc phan tu hien tai
                // thi cap nhat vi tri phu hop.
                if (hamSoSanh(
                    mang[j],
                    mang[viTriPhuHop]
                ) < 0)
                {
                    viTriPhuHop = j;
                }
            }

            if (viTriPhuHop != i)
            {
                HoanVi(
                    ref mang[i],
                    ref mang[viTriPhuHop]
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