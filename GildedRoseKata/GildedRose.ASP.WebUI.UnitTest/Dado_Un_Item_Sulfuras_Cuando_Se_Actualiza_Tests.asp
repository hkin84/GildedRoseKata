<%
Class Dado_Un_Item_Sulfuras_Cuando_Se_Actualiza_Tests

	Public Function TestCaseNames()
		TestCaseNames = Array("Entonces_Calidad_Nunca_Disminuye, Entonces_Sellin_No_Disminuye")
	End Function

	Public Sub SetUp()
		
	End Sub

	Public Sub TearDown()
		
	End Sub

	Public Sub Entonces_Calidad_Nunca_Disminuye(oTestResult)
		'ARRANGE
		Dim expectedQuality 
		expectedQuality = 80

        Dim sut
        Set sut = New Program
        Set objItem = New Item
        objItem.Name = "Sulfuras, Hand of Ragnaros"
        objItem.Sellin = 0
        objItem.Quality = 80
        sut.Items.Add sut.Items.Count, objItem    

		'ACT
		Dim actualQuality
        sut.UpdateQuality()
        actualQuality = sut.Items(0).Quality

		'ASSERT
		
		oTestResult.AssertEquals expectedQuality, actualQuality, "Error Item Sulfuras Disminuye Calidad"
	End Sub

    Public Sub Entonces_Sellin_No_Disminuye(oTestResult)
		'ARRANGE
		Dim expectedSellin 
		expectedSellin = 1

        Dim sut
        Set sut = New Program
       Set objItem = New Item
        objItem.Name = "Sulfuras, Hand of Ragnaros"
        objItem.Sellin = 1
        objItem.Quality = 80
        sut.Items.Add sut.Items.Count, objItem       

		'ACT
		Dim actualSellin
        sut.UpdateQuality()
        actualSellin = sut.Items(0).Sellin

		'ASSERT
		
		oTestResult.AssertEquals expectedSellin, actualSellin, "Error Item Standard Sellin Disminuye"
	End Sub

    
End Class
%>