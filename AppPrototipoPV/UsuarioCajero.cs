using System;

public class Cajero
{
	private int idcajero;
	private String nombrecajero;
	private String usuariocajero;
    private char operarcaja;
    private char abrircajas;


    public Cajero()
    {
    }

    public Cajero(int idcajero, string nombrecajero, string usuariocajero, char operarcaja, char abrircajas)
    {
        this.Idcajero = idcajero;
        this.Nombrecajero = nombrecajero;
        this.Usuariocajero = usuariocajero;
        this.Operarcaja = operarcaja;
        this.Abrircajas = abrircajas;
    }

    public int Idcajero { get => idcajero; set => idcajero = value; }
    public string Nombrecajero { get => nombrecajero; set => nombrecajero = value; }
    public string Usuariocajero { get => usuariocajero; set => usuariocajero = value; }
    public char Operarcaja { get => operarcaja; set => operarcaja = value; }
    public char Abrircajas { get => abrircajas; set => abrircajas = value; }
}
