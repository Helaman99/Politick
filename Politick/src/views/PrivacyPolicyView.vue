<template>
  <div class="privacy-policy">
    <div class="logo">
      <img src="@/assets/logos/politick.svg" />
    </div>

    <div class="content">
      <h1>Privacy Policy for Politick</h1>

      <p>
        At Politick, we are committed to protecting your privacy. This Privacy Policy describes how
        we collect, use, and share information about you when you use our website and services
        (collectively, the "Services").
      </p>

      <h2>What Information We Collect</h2>
      <p>
        When you create an account on our website, we will collect your email address and password.
        We will only use this information to verify your account and to allow you to log into our
        website.
      </p>
      <p>
        When you use our Services, we may also collect information about your interactions with
        other users and the content you create or share. We use this information to provide and
        improve our Services, to personalize your experience, and to better understand how our
        Services are used.
      </p>

      <h2>How We Use Your Information</h2>
      <p>
        We may use your email address to communicate with you about your account and to provide you
        with updates and information about our Services. We will not share your email address with
        any third parties.
      </p>

      <p>
        We may also use the information we collect to analyze user behavior, to improve our
        Services, and to personalize your experience on our website.
      </p>

      <h2>How We Protect Your Information</h2>
      <p>
        We take the security of your personal information very seriously. We use reasonable measures
        to protect your information from unauthorized access, use, or disclosure. However, no
        security system is perfect, and we cannot guarantee the security of your information.
      </p>

      <h2>Who We Share Your Information With</h2>
      <p>We do not share your personal information with any third parties.</p>

      <h2>Your Choices</h2>
      <p>
        You can update or delete your account information at any time by logging into your account
        and accessing your profile settings. You can also contact us at [insert contact information]
        to request that we update or delete your information.
      </p>

      <h2>Payments and Other Services</h2>
      <p>
        We use PayPal for payments and other services. If you wish to use one of these services and
        pay on our website, PayPal may collect the personal data you provide, such as payment and
        other identifying information. PayPal uses this information to operate and improve the
        services it provides to us and others, including for fraud detection, harm and loss
        prevention, authentication, analytics related to the performance of its services, and to
        comply with applicable legal requirements. The processing of this information will be
        subject to the PayPal Privacy Statement available at PayPal.com.
      </p>

      <h2>Contact Us</h2>
      <p>
        If you have any questions or concerns about our Privacy Policy or our data practices, please
        contact us at si-support@protonmail.com.
      </p>

      <h2>Changes to Our Privacy Policy</h2>
      <p>
        We may update this Privacy Policy from time to time. If we make any material changes, we
        will notify you by email or by posting a notice on our website.
      </p>

      <br />
      <p>
        By using our Services, you agree to the terms of this Privacy Policy. If you do not agree to
        the terms of this Privacy Policy, please do not use our Services.
      </p>
    </div>
  </div>
</template>

<style scoped>
h1,
h2,
h3,
h4 {
  margin-top: 1rem;
  font-weight: bold;
}
ul {
  margin-left: 2rem;
}
.privacy-policy {
  width: 75%;
}
.content {
  text-align: left;
  padding: 2rem;
}
.logo {
  width: 100%;
  align-content: center;
}
.logo img {
  width: 60%;
}

@media (max-width: 840px) {
  .privacy-policy {
    width: 90%;
  }
}
@media (max-width: 650px) {
  .privacy-policy {
    width: 100%;
  }
  .content {
    padding: 0;
  }
  .logo img {
    width: 100%;
  }
}
</style>
