package com.example.pillingapp;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;
import java.security.cert.CertificateException;
import java.security.cert.X509Certificate;

import javax.net.ssl.HttpsURLConnection;
import javax.net.ssl.SSLContext;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;
import java.security.SecureRandom;
import java.util.HashMap;
import java.util.Map;

import com.android.volley.toolbox.HurlStack;
public class LoginActivity extends AppCompatActivity {
    Button back_btn,login_btn;
    TextView signup_btn;
    EditText username_edt, password_edt;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        back_btn = findViewById(R.id.back_btn);
        login_btn = findViewById(R.id.login_btn);
        signup_btn = findViewById(R.id.signup_btn);
        username_edt = findViewById(R.id.username_edt);
        password_edt = findViewById(R.id.password_edt);
        back_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(LoginActivity.this, PlashActivity.class);
                startActivity(intent);
            }
        });
        login_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(Validate()){
                    String id = username_edt.getText().toString();
                    String pass = password_edt.getText().toString();
                    CallAPILoginVolley(id,pass);
                }
                else {
                    Toast.makeText(LoginActivity.this, "Type username and password", Toast.LENGTH_SHORT).show();
                }

            }
        });
        signup_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(LoginActivity.this, SignUpActivity.class);
                startActivity(intent);
            }
        });
    }
    void CallAPILoginVolley(String id,String pass){

        RequestQueue queue = Volley.newRequestQueue(this);
        final String SERVER = "http://192.168.178.19:5000/api/Account/login?id="+id+"&pass="+pass;
        Uri.Builder builder = Uri.parse(SERVER).buildUpon();
        String url = builder.build().toString();
        StringRequest stringRequest = new StringRequest(Request.Method.GET, url,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        Log.d("Volleyy",""+response);
                        Toast.makeText(getApplicationContext(), "Login Success",Toast.LENGTH_SHORT).show();
                        Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                        startActivity(intent);
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("Volleyy", error.toString());
                Toast.makeText(LoginActivity.this, "User and password not valid", Toast.LENGTH_SHORT).show();
            }
        });

        queue.add(stringRequest);
    }
    boolean Validate(){
        if(username_edt.getText().equals("")){
            return false;
        }
        if (password_edt.getText().equals("")){
            return false;
        }
        return true;
    }
}


