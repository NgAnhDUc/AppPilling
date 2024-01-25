package com.example.pillingapp.API;

import com.example.pillingapp.Model.User;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.GET;
import retrofit2.http.Query;

public interface ApiServices {

    //https://localhost:44321/api/Account/login?id=0&pass=string
    String BaseURL ="https://localhost:44321/";
    Gson gson = new GsonBuilder()
            .setDateFormat("yyyy-MM-dd HH:mm:ss")
            .create();

    ApiServices apiService = new Retrofit.Builder()
            .baseUrl(BaseURL)
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
            .create(ApiServices.class);

    @GET("api/Account/login")
    Call<User> login(@Query("id") int id,
                     @Query("pass") String pass );

}
