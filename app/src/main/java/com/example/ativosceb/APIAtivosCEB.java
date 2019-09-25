package com.example.ativosceb;

import android.util.Log;

import com.example.ativosceb.model.Ativo;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

public class APIAtivosCEB {

    private static String readStream (InputStream in){
        BufferedReader r = new BufferedReader(new InputStreamReader(in));
        StringBuilder total = new StringBuilder();
        String linha;

        try {
            while ((linha = r.readLine()) != null){
             total.append(linha).append('\n');
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return total.toString();
    }

    private static String request(String stringUrl) throws IOException {
        URL url = null;
        HttpURLConnection urlConnection = null;
        try{
            url = new URL(stringUrl);
            urlConnection = (HttpURLConnection) url.openConnection();
            InputStream in = new BufferedInputStream(urlConnection.getInputStream());
            return readStream(in);
        } catch (Exception ex){
            ex.printStackTrace();
        }
        finally {
            urlConnection.disconnect();
        }
        return "";
    }

    public static Ativo buscarAtivo(int id) throws JSONException, IOException {
        //List<Ativo> lista = new ArrayList();
        String resposta = request("http://webativos.gearhostpreview.com/api/ativo/" + id);
        JSONObject obj = new JSONObject(resposta);
        int idAtivo = obj.getInt("idAtivo");
        int idLocal = obj.getInt("idLocal");
        int idCategoria = obj.getInt("idCategoria");
        int idFabricante = obj.getInt("idFabricante");
        int idPiso = obj.getInt("idPiso");
        int patrimonio = obj.getInt("patrimonio");
        String item = obj.getString("item");
        String notaFiscal = obj.getString("notaFiscal");
        String dataRegistro = obj.getString("dataRegistro");
        String dataRetirada = obj.getString("dataRetirada");
        String garantia = obj.getString("garantia");
        String serviceTag = obj.getString("serviceTag");
        String condicao = obj.getString("condicao");
        String modelo = obj.getString("modelo");
        String numeroSerie = obj.getString("numeroSerie");
        String comentarios = obj.getString("comentarios");
        double valor = obj.getDouble("valor");
        return new Ativo(idAtivo, item, idLocal, idCategoria, idPiso, idFabricante, modelo, comentarios, dataRetirada, dataRegistro, condicao, serviceTag,
                garantia, numeroSerie, notaFiscal, patrimonio, valor);
        //lista.add(ativo);
        //return  lista;
    }
}
