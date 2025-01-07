/** @type {import('next').NextConfig} */
const nextConfig = {
  output: 'standalone',
  env: {
<<<<<<< HEAD
      NEXT_PUBLIC_API_FOR_CLIENT: "http://localhost:5187",
      NEXT_PUBLIC_API_URL: "http://localhost:5187"
=======
      NEXT_PUBLIC_API_FOR_CLIENT: "http://localhost:5187", // not relate to docker's envs
>>>>>>> master
  }
};

export default nextConfig;
