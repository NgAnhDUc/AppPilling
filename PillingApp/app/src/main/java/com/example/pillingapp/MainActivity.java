package com.example.pillingapp;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;

import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.android.material.navigation.NavigationBarView;


public class MainActivity extends AppCompatActivity {

    BottomNavigationView bottomNavigationView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        bottomNavigationView = findViewById(R.id.bottom_nav);
        bottomNavigationView.setOnItemSelectedListener(new NavigationBarView.OnItemSelectedListener() {
            @SuppressLint("NonConstantResourceId")
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                int id = item.getItemId();
                int Home = R.id.action_home;
                int Bill = R.id.action_bill;
                int Contract = R.id.action_contract;
                int Account = R.id.action_account;
                int Setting = R.id.action_setting;

                if (id == Home){
                    Toast.makeText(MainActivity.this, "Home", Toast.LENGTH_SHORT).show();
                }
                if (id == Bill){
                    Toast.makeText(MainActivity.this, "Bill", Toast.LENGTH_SHORT).show();
                }
                if (id == Contract){
                    Toast.makeText(MainActivity.this, "Contract", Toast.LENGTH_SHORT).show();
                }
                if (id == Account){
                    Toast.makeText(MainActivity.this, "Account", Toast.LENGTH_SHORT).show();
                }
                if (id == Setting){
                    Toast.makeText(MainActivity.this, "Setting", Toast.LENGTH_SHORT).show();
                }
                return true;
            }
        });
    }
}