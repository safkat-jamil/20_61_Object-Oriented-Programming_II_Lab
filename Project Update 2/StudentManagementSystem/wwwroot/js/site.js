// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', () => {
    // PASSWORD TOGGLE
    document.querySelectorAll('.password-toggle-btn').forEach(btn => {
        btn.addEventListener('click', function () {
            const input = document.getElementById(this.dataset.target);
            if (!input) return;
            const isText = input.type === 'text';
            input.type = isText ? 'password' : 'text';
            this.innerHTML = isText ? '👁️' : '🙈';
        });
    });

    // CAPTCHA GENERATION & REFRESH
    const disp = document.getElementById('captcha');
    const hid = document.getElementById('CaptchaCode');
    const btn = document.getElementById('refresh-captcha');

    if (disp && hid && btn) {
        const genCode = () => {
            const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
            let c = '';
            for (let i = 0; i < 6; i++) {
                c += chars.charAt(Math.random() * chars.length | 0);
            }
            disp.innerText = c;
            hid.value = c;
        };

        genCode();
        btn.addEventListener('click', e => { e.preventDefault(); genCode(); });
    }
});