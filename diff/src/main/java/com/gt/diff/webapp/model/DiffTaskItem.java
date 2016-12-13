package com.gt.diff.webapp.model;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.extern.log4j.Log4j2;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

@Data
@NoArgsConstructor
/**
 * The DiffTaskItem class is responsible to keep the contents to be compared
 * by DiffTask. It will hold a hash of its value to speed up comparison.
 */
public class DiffTaskItem {
    private String content;
    private String hash;

    /**
     * Set the content for comparison. Calculate a hash on assignment.
     * @param content in Base64 format
     */
    public void setContent(String content) {
        this.content = content;
        try {
            MessageDigest digest = MessageDigest.getInstance("SHA-1");
            byte[] md = digest.digest(this.content.getBytes());
            StringBuilder hex = new StringBuilder();
            for (byte b : md) {
                hex.append(Integer.toHexString(0xff & b));
            }
            this.hash = hex.toString();
        } catch (NoSuchAlgorithmException e) {
            System.out.println(e.getMessage());
        }
    }
}
