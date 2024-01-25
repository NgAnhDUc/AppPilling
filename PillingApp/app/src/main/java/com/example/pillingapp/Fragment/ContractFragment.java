package com.example.pillingapp.Fragment;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;

import com.example.pillingapp.R;


public class ContractFragment extends Fragment {
    Button none_contract_btn;
    LinearLayout none_contract_layout;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_contract, container, false);
        none_contract_btn =view.findViewById(R.id.none_contract_btn);
        none_contract_layout =view.findViewById(R.id.none_contract_layout);
        none_contract_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
            none_contract_layout.setVisibility(View.GONE);
            }
        });
        return view;
    }
}