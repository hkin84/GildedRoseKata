<!-- #include virtual="defaultController.asp"-->
<%
Class Dado_Un_Item_Cuando_Se_Actualiza_Tests

	Public Function TestCaseNames()
		TestCaseNames = Array("Entonces_Calidad_Item_Menos_1, Y_Pasada_Fecha_Venta_Entonces_Calidad_Item_Menos_2")
	End Function

	Public Sub SetUp()
		
	End Sub

	Public Sub TearDown()
		
	End Sub

	Public Sub Entonces_Calidad_Item_Menos_1(oTestResult)
		'ARRANGE
		Dim expectedQuality 
		expectedQuality = 19

        Dim sut
        Set sut = New Program
        Dim objItem
        Set objItem = New Item
        objItem.Name = "+5 Dexterity Vest"
        objItem.Sellin = 10
        objItem.Quality = 20
        sut.Items.Add sut.Items.Count, objItem    

		'ACT
		Dim actualQuality
        sut.UpdateQuality()
        actualQuality = sut.Items(0).Quality

		'ASSERT
		
		oTestResult.AssertEquals expectedQuality, actualQuality, "Error Item Standard Actualizar Item no degrada Calidad"
	End Sub

    Public Sub Y_Pasada_Fecha_Venta_Entonces_Calidad_Item_Menos_2(oTestResult)
		'ARRANGE
		Dim expectedQuality 
		expectedQuality = 18

        Dim sut
        Set sut = New Program
        Dim objItem
        Set objItem = New Item
        objItem.Name = "+5 Dexterity Vest"
        objItem.Sellin = 0
        objItem.Quality = 20
        sut.Items.Add sut.Items.Count, objItem    

		'ACT
		Dim actualQuality
        sut.UpdateQuality()
        actualQuality = sut.Items(0).Quality

		'ASSERT
		
		oTestResult.AssertEquals expectedQuality, actualQuality, "Error Item Standard Actualizar Item no degrada Calidad doble"
	End Sub

End Class
%>
