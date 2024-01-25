package com.example.pillingapp;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import java.util.HashMap;
import java.util.Map;

public class SignUpActivity extends AppCompatActivity {
    Button back_btn,signup_btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_up);
        back_btn = findViewById(R.id.back_btn);
        signup_btn = findViewById(R.id.signup_btn);
        back_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(SignUpActivity.this, LoginActivity.class);
                startActivity(intent);
            }
        });
        signup_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                callAPISignUp();
                Intent intent = new Intent(SignUpActivity.this, LoginActivity.class);
                startActivity(intent);
            }
        });
    }
    void callAPISignUp(){
        RequestQueue queue = Volley.newRequestQueue(this);
        final String SERVER = "http://192.168.178.19:5000/api/Account";
        Uri.Builder builder = Uri.parse(SERVER).buildUpon();
        String url = builder.build().toString();
        StringRequest stringRequest = new StringRequest(Request.Method.POST, url,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        Log.d("VolleyySign",""+response);
                        Toast.makeText(getApplicationContext(), "Sign Up Success",Toast.LENGTH_SHORT).show();
                        Intent intent = new Intent(SignUpActivity.this, LoginActivity.class);
                        startActivity(intent);
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("VolleyySign", error.toString());
                Toast.makeText(SignUpActivity.this, "Failed"+error, Toast.LENGTH_SHORT).show();
            }
        }){
            @Nullable
            @Override
            protected Map<String, String> getParams() throws AuthFailureError {
                Map<String,String> map = new HashMap<>();
                map.put("cmnd","5");
                map.put("idNguoidung","0");
                map.put("maNv","0");
                map.put("passwordd","1122334455");
                map.put("rolee","0");
                map.put("ten","string");
                map.put("email","string");
                map.put("gioiTinh","string");
                map.put("diachi","string");
                return map;
            }
        };

        queue.add(stringRequest);
    }
}