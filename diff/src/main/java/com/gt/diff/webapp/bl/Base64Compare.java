package com.gt.diff.webapp.bl;

import java.io.ByteArrayOutputStream;
import java.util.Map;
import java.util.TreeMap;

/**
 * Small helper to decode a base64 string.
 */
class Base64Compare {

    /**
     * char codes table.
     */
    private static char[] codes = new char[]{'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/'};

    /**
     * Decode helper.
     *
     * @param c encoded char.
     * @return decoded char.
     */
    private int indexOf(char c) {
        if (c >= 'A' && c <= 'Z')
            return c - 'A';
        if (c >= 'a' && c <= 'z')
            return (c - 'a') + 26;
        if (c >= '0' && c <= '9')
            return (c - '0') + 52;
        if (c == '+')
            return 62;
        if (c == '/')
            return 63;
        return 64;
    }

    /**
     * Decode a string in Base64 format.
     *
     * @param in Base64 encoded string.
     * @return Decoded string. It could be improved by returning
     * the OutputStream and comparing it directly.
     */
    private String decode(final String in) {
        ByteArrayOutputStream out = new ByteArrayOutputStream();
        for (int i = 0; i < in.length(); i += 4) {
            int[] b = new int[4];
            b[0] = indexOf(in.charAt(i));
            b[1] = indexOf(in.charAt(i + 1));
            b[2] = indexOf(in.charAt(i + 2));
            b[3] = indexOf(in.charAt(i + 3));
            out.write((b[0] << 2) | (b[1] >> 4));
            if (b[2] < 64) {
                out.write((b[1] << 4) | (b[2] >> 2));
                if (b[3] < 64) {
                    out.write((b[2] << 6) | b[3]);
                }
            }
        }
        return new String(out.toByteArray());
    }

    /**
     * The compare helper. Takes to strings in Base64 format, decodes them and compare byte by byte.
     *
     * @param left  Base64 format content for left part.
     * @param right Base64 format content for right part.
     * @return A DiffTaskResult object containing the operation result: contents are equal, contents
     * have different sizes, or map containing offset and length for different content.
     * @throws Exception if inputs are not equal in size or not a Base64 string.
     */
    Map<Integer, Integer> compare(final String left, final String right) throws Exception {

        if (left == null || right == null) {
            throw new IllegalArgumentException("invalid input specified");
        }

        if (left.length() != right.length()) {
            throw new IllegalArgumentException("sizes not equal");
        }

        if ((left.length() % 4) != 0) {
            throw new IllegalArgumentException("invalid base64 input");
        }

        String leftDecoded = decode(left);
        String rightDecoded = decode(right);

        Map<Integer, Integer> result = new TreeMap<>();
        int off, cnt;
        for (int i = 0, j = 0; i < leftDecoded.length(); i++, j++) {
            if (leftDecoded.charAt(i) != rightDecoded.charAt(j)) {
                cnt = 0;
                off = i;
                while (i < leftDecoded.length() && leftDecoded.charAt(i) != rightDecoded.charAt(j)) {
                    cnt++;
                    i++;
                    j++;
                }
                result.put(off, cnt);
            }
        }
        return result;
    }
}
