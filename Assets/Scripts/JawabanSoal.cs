using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabanSoal : MonoBehaviour
{
    private string outputNo6 = "";
    private float outputNo7 = 100f;

	public void JawabanNo6()
    {
        // Saya menghindari else if berulang yang menggunakan AND atau OR
        for (int i = 0; i < 100; i++)
        {
			outputNo6 = "";

			if ((i + 1) % 2 == 0)
            {
                outputNo6 += "Fun";
            }
            if ((i + 1) % 7 == 0)
            {
                outputNo6 += "Run";
            }

            if (outputNo6 == "")
            {
                Debug.Log(i + 1);
            }
            else
            {
                Debug.Log(outputNo6);
            }
        }
    }

    public void JawabanNo7()
    {
        // Saya tidak mengabaikan dan tidak memberi batasan angka di belakang koma
        outputNo7 = 100;

        for (int i = 0; i < 50; i++)
        {
            outputNo7 = outputNo7 * 1.1f;
            print("Tinggi pohon mangga disemprotan ke-" + (i + 1) + " adalah " + outputNo7);
        }
    }
}
