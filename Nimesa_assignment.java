//Problem

/*https://samples.openweathermap.org/data/2.5/forecast/hourly?q=London,us&appid=b6907d289e10d714a6e88b30761fae22
The above API is the REST GET API
Which gives you the response in JSON format and hourly weather forecast of London Location

I want you to write a program to get the option from the user and print the result based on the above API.
1. Get weather
2. Get Wind Speed
3. Get Pressure
0. Exit

If the user press 1, Prompt the user for the date then print the temp of the input date.
If the user press 2, Prompt the user for the date then print the wind.speed of the input date.
If the user press 3, Prompt the user for the date then print the pressure of the input date.
If the user press 0, Terminate the program.

The program should not terminate until the user press 0.
The program should be modular.*/

//Solution in Java

package Nimesa_Assignments;

import  java.net.HttpURLConnection;
import  java.net.URL;
import 	java.util.Scanner;
import org.json.JSONObject;
import org.json.JSONArray;




public class jsonreader 
{
	static Scanner sc;
	static Scanner sc1=new Scanner(System.in);
	private static HttpURLConnection conn;
	static String line="";
	public static void main(String[] args) 
	{
		try
		{
			URL Endpoint=new URL("https://samples.openweathermap.org/data/2.5/forecast/hourly?q=London,us&appid=b6907d289e10d714a6e88b30761fae22");
			conn=(HttpURLConnection)Endpoint.openConnection();
			conn.setRequestMethod("GET");
			int responcecode=conn.getResponseCode();
			System.out.println(responcecode);
			sc=new Scanner(Endpoint.openStream());
			while(sc.hasNext())
			{
				line+=sc.nextLine();
				//System.out.println(line);
			}
			long epoch=0;
			try 
			{

				System.out.println(epoch);
			} 
			catch(Exception e) 
			{
			    System.out.println(e);
			}
			jsonreader json=new jsonreader();
			
			while(true)
			{
				System.out.println("\nChoose option for getting weather forecast\n\n"
						+ "   Enter 1 for Temperature\n\n   Enter 2 for Wind Speed\n\n   Enter 3 for Pressure \n\n   Enter 0 for Exit!...");
				int input=sc1.nextInt();
				sc1.nextLine();
				if(input==1)
				{
					json.getTemperature(line);
				}
				else if(input==2)
				{
					json.getWindSpeed(line);
				}
				else if(input==3)
				{
					json.getPressure(line);
				}
				else if(input==0)
				{
					System.out.println("Thanks for using :)");
					System.exit(0);
				}
				else
				{
					System.out.println("OOps ! Invalid Input...");
				}
				
				
			}

			
		
		}
		catch(Exception exc)
		{
			System.out.print(exc);
		}
			
		
	}
	void getTemperature(String line)
	{
		try
		{
			System.out.println("Enter date");	
			long mydate = (new java.text.SimpleDateFormat("dd/MM/yyyy").parse(sc1.nextLine()).getTime() / 1000)+19800;
			JSONObject object=new JSONObject(line);
			JSONArray list=object.getJSONArray("list");
			for(int i=0;i<list.length();i++)
			{
				JSONObject inList=list.getJSONObject(i);
				//System.out.println(inList.toString());
				//System.out.println("before if"+mydate+"-"+inList.getLong("dt"));
				long dt=inList.getLong("dt");
				if(mydate<=dt )
				{
					if((mydate+86400)<=dt){
						//System.out.println("break"+mydate+"-"+dt);
						break;}
					//System.out.println("after if"+mydate+"-"+dt);
					System.out.print("Temperature on "+inList.getString("dt_txt")+"--> ");
					JSONObject main=inList.getJSONObject("main");
					System.out.println(main.getDouble("temp")+" Kelvin");
					
				}
				
			}
		}
		catch(Exception exc)
		{
			System.out.println(exc);
		}
		
	}
	void getPressure(String line)
	{
		try
		{
			System.out.println("Enter date");	
			long mydate = (new java.text.SimpleDateFormat("dd/MM/yyyy").parse(sc1.nextLine()).getTime() / 1000)+19800;
			JSONObject object=new JSONObject(line);
			JSONArray list=object.getJSONArray("list");
			for(int i=0;i<list.length();i++)
			{
				JSONObject inList=list.getJSONObject(i);
				//System.out.println(inList.toString());
				//System.out.println("before if"+mydate+"-"+inList.getLong("dt"));
				long dt=inList.getLong("dt");
				if(mydate<=dt )
				{
					if((mydate+86400)<=dt){
						//System.out.println("break"+mydate+"-"+dt);
						break;}
					//System.out.println("after if"+mydate+"-"+dt);
					System.out.print("Presure on "+inList.getString("dt_txt")+"--> ");
					JSONObject main=inList.getJSONObject("main");
					System.out.println(main.getDouble("pressure")+" Pascal");
					
				}
				
			}
		}
		catch(Exception exc)
		{
			System.out.println(exc);
		}
		
		
	}
	void getWindSpeed(String line)
	{
		try
		{
			System.out.println("Enter date");	
			long mydate = (new java.text.SimpleDateFormat("dd/MM/yyyy").parse(sc1.nextLine()).getTime() / 1000)+19800;
			JSONObject object=new JSONObject(line);
			JSONArray list=object.getJSONArray("list");
			for(int i=0;i<list.length();i++)
			{
				JSONObject inList=list.getJSONObject(i);
				//System.out.println(inList.toString());
				//System.out.println("before if"+mydate+"-"+inList.getLong("dt"));
				long dt=inList.getLong("dt");
				if(mydate<=dt )
				{
					if((mydate+86400)<=dt){
						//System.out.println("break"+mydate+"-"+dt);
						break;}
					//System.out.println("after if"+mydate+"-"+dt);
					System.out.print("Wind Speed on "+inList.getString("dt_txt")+"--> ");
					JSONObject main=inList.getJSONObject("wind");
					System.out.println(main.getDouble("speed")+" Km/s");
					
				}
				
			}
		}
		catch(Exception exc)
		{
			System.out.println(exc);
		}
	}

}

