Module StadiaBBDD

    'https://stadiasource.com
    'https://stadiadb.app/

    Public Function Listado()

        Dim lista As New List(Of StadiaBBDDEntrada) From {
            New StadiaBBDDEntrada("Ary and the Secret of Seasons", "016636d5f49f4862be3ff8cbcf6c7adercp1", "935570"),
            New StadiaBBDDEntrada("Assassin's Creed Origins", "11dfda5b2d78475d8624972b9b78c995rcp1", "582160"),
            New StadiaBBDDEntrada("Assassin's Creed Syndicate", "88a2945345f744519c5148ddd54f26d1rcp1", "368500"),
            New StadiaBBDDEntrada("Assassin's Creed Unity", "92f77c19718444499ffb3054dd97ca36rcp1", "289650"),
            New StadiaBBDDEntrada("Assassin's Creed Valhalla", "377f50584071472096bcda89b0839bc3rcp1", Nothing),
            New StadiaBBDDEntrada("Baldur's Gate 3", "41de509cbdbb4a13828636099c57731arcp1", "1086940"),
            New StadiaBBDDEntrada("Cake Bash", "19efd5fa36794d7b8bc87de68124e705rcp1", "971690"),
            New StadiaBBDDEntrada("Celeste", "c911998e4f8d4c6ea6712c5ad33e4a54rcp1", "504230"),
            New StadiaBBDDEntrada("Chronos: Before the Ashes", "3f94b62fa50c4202be10472947478f8frcp1", "967390"),
            New StadiaBBDDEntrada("Crayta", "05f66a46027747a08b930ea70374ac7frcp1", Nothing),
            New StadiaBBDDEntrada("Cthulhu Saves Christmas", "769a088b9ef04c04b341911a1ef8b8ecrcp1", "1057540"),
            New StadiaBBDDEntrada("Cyberpunk 2077", "49697e672bc34e7d8a5f73f78cb580d0rcp1", "1091500"),
            New StadiaBBDDEntrada("Dead by Daylight", "b67e43f2b05f4ba7acc56a4b222568aarcp1", "381210"),
            New StadiaBBDDEntrada("Destroy All Humans!", "0fd3103549b54c7e89afd6eed83672cercp1", "803330"),
            New StadiaBBDDEntrada("DOOM", "cc1a8e0e94d54f15a22149fed93bbd7arcp1", "379720"),
            New StadiaBBDDEntrada("El Hijo - A Wild West Tale", "d46f9c2d858d41d6ae4cc12d186657f0rcp1", "853050"),
            New StadiaBBDDEntrada("Enter The Gungeon", "8f0addba5d3d4c05b07d7b59481e0171rcp1", "311690"),
            New StadiaBBDDEntrada("Everspace", "44752f1774ca4508a2c45e57121d7e8frcp1", "396750"),
            New StadiaBBDDEntrada("F1 2020", "f3519f3dc3d74fbb8086520577b832e0rcp1", "1080110"),
            New StadiaBBDDEntrada("Family Feud", "5ba98de70c8c4b64bf56ca9009d60e62rcp1", Nothing),
            New StadiaBBDDEntrada("Far Cry 5", "7d9beb13648d44839b9aeea7555c37c0rcp1", "552520"),
            New StadiaBBDDEntrada("Far Cry New Dawn", "a2a4ff75e249404a975db7ae5f77e536rcp1", "939960"),
            New StadiaBBDDEntrada("Figment", "7183914d07034cb1bbb8a511779bc1efrcp1", "493540"),
            New StadiaBBDDEntrada("Gods Will Fall", "f001c122cb70445d8a247d5b6f6334cbrcp1", "1243690"),
            New StadiaBBDDEntrada("Gunsport", "16330bd770134d85b5bef3cc6b1407ffrcp1", Nothing),
            New StadiaBBDDEntrada("Hello Neighbor", "9dc548a191914b419cc80802ca64788frcp1", "521890"),
            New StadiaBBDDEntrada("Hello Neighbor: Hide and Seek", "cf784a0f4c554ce68a2880cb461bd903rcp1", "960420"),
            New StadiaBBDDEntrada("HITMAN", "990ec302c2cd4ba7817cedcf633ab20frcp1", "236870"),
            New StadiaBBDDEntrada("Hotline Miami", "5f54e869de4441f8998e80d2c54fa74brcp1", "219150"),
            New StadiaBBDDEntrada("Hotline Miami 2: Wrong Number", "68add0d67fe3491f94cb439664b1ffc7rcp1", "274170"),
            New StadiaBBDDEntrada("Human: Fall Flat", "16d98de80a3340ffa4129953ae4e3206rcp1", "477160"),
            New StadiaBBDDEntrada("Immortals Fenyx Rising", "161f276db10947a199cd0260ed4dc248rcp1", Nothing),
            New StadiaBBDDEntrada("Into The Breach", "1a871cfe8a7d4ebc8592c2ad4bc07150rcp1", "590380"),
            New StadiaBBDDEntrada("Just Dance 2021", "b87ca389d6454546af28dff82898406arcp1", Nothing),
            New StadiaBBDDEntrada("Kona", "f5f9708a422a44cc876c240cfa07221drcp1", "365160"),
            New StadiaBBDDEntrada("Lara Croft and the Guardian of Light", "29b3d5d6788f444c8cd59aa0a49d1bd1rcp1", "35130"),
            New StadiaBBDDEntrada("Lara Croft and the Temple of Osiris", "6d0d865669774338b3ce888a84da6cdercp1", "289690"),
            New StadiaBBDDEntrada("Little Big Workshop", "e4e8f5e5bc744270a644c554ba3f2962rcp1", "574720"),
            New StadiaBBDDEntrada("Madden NFL 21", "0e6c703afde840148204847447b9c21drcp1", "1239520"),
            New StadiaBBDDEntrada("Marvel's Avengers", "232ff8abc7f74421a477e9e09dbf487drcp1", "997070"),
            New StadiaBBDDEntrada("Monster Boy and the Cursed Kingdom", "ef14fb2f692c4b42b4b092d3e7864cd8rcp1", "449610"),
            New StadiaBBDDEntrada("Monster Jam Steel Titans", "e7506ec75c8046dfa7879fe604505ca7rcp1", "824280"),
            New StadiaBBDDEntrada("NBA 2K21", "b0a2ab7cdc194582bc4d111c07c2e30drcp1", "1225330"),
            New StadiaBBDDEntrada("One Hand Clapping", "76309b9f2f294b07b410e8b6aa879273rcp1", "893720"),
            New StadiaBBDDEntrada("Orcs Must Die! 3", "c1928530515748da9f55afc7243fd3e1rcp1", Nothing),
            New StadiaBBDDEntrada("Outcasters", "8533fb04b9174c3f8dce10a2fec7b062rcp1", Nothing),
            New StadiaBBDDEntrada("Outward", "8185df0ce9d74d61aab58a12d4bf21a0rcp1", "794260"),
            New StadiaBBDDEntrada("PAC-MAN Mega Tunnel Battle", "9affbc684aeb422086bfb5d0c8bf2f55rcp1", Nothing),
            New StadiaBBDDEntrada("PGA TOUR 2K21", "6a2ac2fc8e684c41b5c14981dcb454fdrcp1", "1016120"),
            New StadiaBBDDEntrada("Phoenix Point", "18ea8c5d2f7e4f40ad783a512da8ef91rcp1", "839770"),
            New StadiaBBDDEntrada("PHOGS", "05b9db9b9b5b489995568afd930a9db3rcp1", "850320"),
            New StadiaBBDDEntrada("Reigns", "2677ffb357f946e29b4e86a9f18ea55frcp1", "474750"),
            New StadiaBBDDEntrada("Relicta", "ed05d9df2ec4452594b07336e360a1aarcp1", "941570"),
            New StadiaBBDDEntrada("Republique", "65864a95f9e74129845bda0467486413rcp1", "317100"),
            New StadiaBBDDEntrada("Risk of Rain 2", "7b6d79b833354dcaa9b2461086a7763crcp1", "632360"),
            New StadiaBBDDEntrada("Rock of Ages 3: Make & Break", "d3d8e467203d401387857d5b6cc27263rcp1", "1101360"),
            New StadiaBBDDEntrada("Scott Pilgrim vs. The World: The Game", "a3725b4a70aa4447b4c193125f3a2529rcp1", Nothing),
            New StadiaBBDDEntrada("Secret Neighbor", "8f8d583a2ae843e0b31fa653cea5d27drcp1", "859570"),
            New StadiaBBDDEntrada("Sekiro: Shadows Die Twice", "cc3f233990754f77a5819a583594f399rcp1", "814380"),
            New StadiaBBDDEntrada("Serious Sam 4", "b3bd32ef05444a189dcdc88f8e85d7f2rcp1", "257420"),
            New StadiaBBDDEntrada("Sniper Elite 4", "1376a179ca87458b85acd44341854772rcp1", "312660"),
            New StadiaBBDDEntrada("Spiritfarer", "430bbe284fb7482c9afe8e877b119269rcp1", "972660"),
            New StadiaBBDDEntrada("SpongeBob SquarePants: Battle for Bikini Bottom Rehydrated", "53bd183291e340dda697167108d3dc6brcp1", "969990"),
            New StadiaBBDDEntrada("Star Wars Jedi: Fallen Order", "36c01626f21f428e8d5ae35ce19c774brcp1", "1172380"),
            New StadiaBBDDEntrada("Strange Brigade", "8e77c7a4368944589b4c9d8179d2eb4crcp1", "312670"),
            New StadiaBBDDEntrada("Submerged: Hidden Depths", "3c39a33bbc064308941f9276c38c30e7rcp1", Nothing),
            New StadiaBBDDEntrada("Super Bomberman R Online", "2847419bbb5146ed877a308d9884f504rcp1", Nothing),
            New StadiaBBDDEntrada("SUPERHOT: MIND CONTROL DELETE", "382fe14629e148449e7b8f94e8aecb38rcp1", "690040"),
            New StadiaBBDDEntrada("The Gardens Between", "cf65dc95d523465493d6fbc482452227rcp1", "600990"),
            New StadiaBBDDEntrada("TOHU", "df0f55ed73d946b8a70398fea9805e2drcp1", "1075200"),
            New StadiaBBDDEntrada("Tom Clancy's Ghost Recon Wildlands", "a1ce1274a83244f1a099bebef7ae1233rcp1", "460930"),
            New StadiaBBDDEntrada("UNO", "1694aaa3968344228424092f180a3e0ercp1", "470220"),
            New StadiaBBDDEntrada("Unto The End", "a089691b36254f77bc66a75052fc7cf6rcp1", "600080"),
            New StadiaBBDDEntrada("Valkyria Chronicles 4", "b00e2f20b91e43c8a0597b07fc80ca84rcp1", "790820"),
            New StadiaBBDDEntrada("Watch Dogs", "b7503867ccbc4ac7be7093fe3ba1523crcp1", "243470"),
            New StadiaBBDDEntrada("Watch Dogs 2", "e6005e58d6d3458abd01bcf68e264ccercp1", "447040"),
            New StadiaBBDDEntrada("Watch Dogs Legion", "deb490c166544813bf2ab73f4c6e2aa0rcp1", Nothing),
            New StadiaBBDDEntrada("West of Loathing", "0a60fff637b445a797623d0c69433a9crcp1", "597220"),
            New StadiaBBDDEntrada("Windbound", "657210fe20ad402b85bda8f816b80d98rcp1", "1162130"),
            New StadiaBBDDEntrada("WWE 2K Battlegrounds", "f28e66bbd0984c77ac6a54e8cc3007bdrcp1", "1142100")
        }

        Return lista
    End Function

    Public Class StadiaBBDDEntrada

        Public Titulo As String
        Public IDStadia As String
        Public IDSteam As String

        Public Sub New(titulo As String, idStadia As String, idSteam As String)
            Me.Titulo = titulo
            Me.IDStadia = idStadia
            Me.IDSteam = idSteam
        End Sub

    End Class

End Module
