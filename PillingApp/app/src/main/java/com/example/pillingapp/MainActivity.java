package com.example.pillingapp;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.viewpager.widget.ViewPager;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.MenuItem;

import com.example.pillingapp.Fragment.AccountFragment;
import com.example.pillingapp.Fragment.BillFragment;
import com.example.pillingapp.Fragment.ContractFragment;
import com.example.pillingapp.Fragment.HomeFragment;
import com.example.pillingapp.Fragment.SettingFragment;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.android.material.navigation.NavigationBarView;


public class MainActivity extends AppCompatActivity {

    BottomNavigationView bottomNavigationView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        bottomNavigationView = findViewById(R.id.bottom_nav);
        setUpFragment(new HomeFragment());
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
                    setUpFragment(new HomeFragment());
                }
                if (id == Bill){
                    setUpFragment(new BillFragment());
                }
                if (id == Contract){
                    setUpFragment(new ContractFragment());
                }
                if (id == Account){
                    setUpFragment(new AccountFragment());
                }
                if (id == Setting){
                    setUpFragment(new SettingFragment());
                }
                return true;
            }
        });
    }
    private void setUpFragment(Fragment fragment){
        FragmentManager fragmentManager = getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
        fragmentTransaction.replace(R.id.viewpager,fragment);
        fragmentTransaction.commit();
    }
}