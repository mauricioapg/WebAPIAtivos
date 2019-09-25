package com.example.ativosceb.activities;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.os.StrictMode;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v4.app.ActivityCompat;
import android.util.Log;
import android.view.View;
import android.support.v4.view.GravityCompat;
import android.support.v7.app.ActionBarDrawerToggle;
import android.view.MenuItem;
import android.support.design.widget.NavigationView;
import android.support.v4.widget.DrawerLayout;

import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.ativosceb.APIAtivosCEB;
import com.example.ativosceb.R;
import com.example.ativosceb.adapters.AdapterListAtivos;
import com.example.ativosceb.model.Ativo;

import org.json.JSONException;

import java.io.IOException;
import java.util.List;

public class ActivityTodosAtivos extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {

    private TextView labelID;
    private TextView labelItem;
    private ListView listViewTodosAtivos;
    private List<Ativo> listaAtivos;
    private AdapterListAtivos adapterListaAtivos;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_todos_ativos);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        FloatingActionButton fab = findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });
        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        NavigationView navigationView = findViewById(R.id.nav_view);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.addDrawerListener(toggle);
        toggle.syncState();
        navigationView.setNavigationItemSelectedListener(this);

        View v = navigationView.getHeaderView(0);
        labelID = (TextView) v.findViewById(R.id.labelID);
        labelItem = (TextView) v.findViewById(R.id.labelItem);
        this.listViewTodosAtivos = (ListView) findViewById(R.id.ListViewTodosAtivos);

        //GAMBIARRA TEMPORÁRIA PARA RESOLVER ACESSO À INTERNET
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        try {
            if(ActivityCompat.checkSelfPermission(this, Manifest.permission.INTERNET) != PackageManager.PERMISSION_GRANTED){
                ActivityCompat.requestPermissions(this, new String[]{Manifest.permission.INTERNET}, 1);
            }
            else {
                carregarAtivo();
            }
        } catch (Exception e) {
            Toast.makeText(this, e.getMessage(), Toast.LENGTH_LONG).show();
        }
    }

    private void carregarAtivo() throws JSONException, IOException {
        //this.listaAtivos = APIAtivosCEB.buscarAtivo(1);
        this.adapterListaAtivos = new AdapterListAtivos(ActivityTodosAtivos.this, this.listaAtivos);
        this.listViewTodosAtivos.setAdapter(this.adapterListaAtivos);
        for(int i=0; i < listaAtivos.size(); i++){
            Log.d("QUANTIDADE ATIVOS////", String.valueOf(listaAtivos.size()));
        }
    }

    public void onRequestPermissionResult(int requestCode, String permissions[], int [] granResults) throws JSONException, IOException {
        switch (requestCode){
            case 1:{
                if(granResults.length > 0 && granResults[0] == PackageManager.PERMISSION_GRANTED){
                    carregarAtivo();
                }
                else {
                    Toast.makeText(this, "ERRO DE PERMISSÃO DE INTERNET", Toast.LENGTH_LONG).show();
                }
            }
        }
    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.activity_todos_ativos, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        if (id == R.id.nav_NovoAtivo) {
            Intent intent = new Intent(ActivityTodosAtivos.this, ActivityNovoAtivo.class);
            startActivity(intent);
        } else if (id == R.id.nav_ListaAtivos) {
            Intent intent = new Intent(ActivityTodosAtivos.this, ActivityListaAtivos.class);
            startActivity(intent);
        } else if (id == R.id.nav_Localizar) {

        } else if (id == R.id.nav_tools) {

        }

        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }
}
